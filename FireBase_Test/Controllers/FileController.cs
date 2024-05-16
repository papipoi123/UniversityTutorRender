using Applications.Utils;
using Applications.Utils.FireBase;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FireBase_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly FirebaseStorageHelper _helper;

        public FileController(FirebaseStorageHelper firebaseStorage)
        {
            this._helper = firebaseStorage;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file,[Required] string filename,string storagePath)
        {

            var downloadUrl = await _helper.UploadFileAsync(file, filename, storagePath);
            // You can return the download URL or any other response as needed
            return Ok(downloadUrl);

        }
        [HttpPut]
        public async Task<IActionResult> Delete(IFormFile file, [Required] string filename, string storagePath, [Required] string oldUrl)
        {

           var downloadUrl =  await _helper.UpdateFileAsync(file, oldUrl,  filename, storagePath);
            // You can return the download URL or any other response as needed
            return Ok(downloadUrl);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete([Required] string filename, string storagePath)
        {

            await _helper.DeleteFileAsync( filename, storagePath);
            // You can return the download URL or any other response as needed
            return Ok("Deleted!");

        }
    }
}