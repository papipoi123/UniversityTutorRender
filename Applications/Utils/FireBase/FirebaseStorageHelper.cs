using Applications.Commons;
using Firebase.Storage;
using FirebaseAdmin;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;

namespace Applications.Utils.FireBase
{
    public class FirebaseStorageHelper
    {
        private FirebaseStorage _storage;

        public FirebaseStorageHelper(FirebaseConfig fireBaseConfig)
        {
            // Initialize Firebase Storage
            _storage = new FirebaseStorage(fireBaseConfig.StorageBucket);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string fileName, string storagePath)
        {
            try
            {
                if (file == null || file.Length == 0) throw new HttpRequestException("File Upload is empty! ", null, HttpStatusCode.NotAcceptable);
                using (var stream = file.OpenReadStream())
                {
                    ReformatFileName(file,ref fileName);
                    var fullPath = $"{storagePath}/{fileName}";
                    var sparklyRef = _storage.Child(fullPath);
                    var downloadUrl = await sparklyRef.PutAsync(stream);
                    return downloadUrl;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here and return an error response
                throw new HttpRequestException($"Error uploading file: {ex.Message}", null, HttpStatusCode.BadRequest);
            }
        }

        private void ReformatFileName(IFormFile file, ref string fileName)
        {
            if (fileName.IndexOf(".") == -1) fileName += file.FileName.Substring(file.FileName.LastIndexOf('.'));
        }

        public async Task<string> UpdateFileAsync(IFormFile file,[Required] string oldImgUrl, string fileName, string storagePath)
        {
            try
            {
                if (file == null || file.Length == 0) throw new HttpRequestException("File Upload is empty! ", null, HttpStatusCode.NotAcceptable);
                if(string.IsNullOrEmpty(oldImgUrl)) throw new HttpRequestException("Please Insert old Img Url! ", null, HttpStatusCode.NotAcceptable);
                using (var newStream = file.OpenReadStream())
                {
                    ReformatFileName(file, ref fileName);

                    var fullPath = $"{storagePath}/{fileName}";
                    var storageRef = _storage.Child(fullPath);
                    var oldRef = GetRef(oldImgUrl);
                    // First, delete the existing file if it exists
                    await oldRef.DeleteAsync();
                    // Then, upload the new file with updated content
                    var downloadUrl = await storageRef.PutAsync(newStream);
                    return downloadUrl;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here and return an error response
                throw new HttpRequestException($"Error Updating file: {ex.Message}", null, HttpStatusCode.BadRequest);
            }
        }

        private FirebaseStorageReference GetRef(string oldImgUrl)
        {
            var uri = new Uri(oldImgUrl);
            var oldPath = uri.Segments.Last().Replace("%2F", "/");
            var oldRef = _storage.Child(oldPath);
            return oldRef;
        }

        public async Task DeleteFileAsync(string fileName, string storagePath)
        {
            try
            {
                var fullPath = $"{storagePath}/{fileName}";
                var storageRef = _storage.Child(fullPath);
                // Delete the file
                await storageRef.DeleteAsync();
            }
            catch (Exception ex)
            {
                // Handle any exceptions here and return an error response
                throw new HttpRequestException($"Error deleting file: {ex.Message}", null, HttpStatusCode.BadRequest);
            }
        }

    }
}
