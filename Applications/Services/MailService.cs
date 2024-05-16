using Applications.Commons;
using Applications.Interfaces;
using Applications.ViewModels;
using System.Net;
using System.Net.Mail;

namespace Applications.Services
{
    public class MailService : IMailService
    {
        public static string to;
        private readonly IUnitOfWork _unitOfWork;

        public MailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> SendAsync(string email)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(email);

            if (user is null)
            {
                return new Response(HttpStatusCode.NotFound, "Email is not found!");
            }

            var randomCode = Random.Shared.Next(100000, 999999).ToString();
            user.CodeResetPassword = randomCode;
            user.ResetCodeExpires = DateTime.Now.AddMinutes(15);
            await _unitOfWork.SaveChangeAsync();
            MailMessage message = new MailMessage();
            to = email;
            MailDataViewModel viewModel = new MailDataViewModel
            {
                From = "dohuuduc315@gmail.com",
                Pass = "preugjpraltpfzdk",
                Body = "Your reset code is " + randomCode,
            };
            message.To.Add(to);
            message.From = new MailAddress(viewModel.From);
            message.Body = viewModel.Body;
            message.Subject = "Password reseting code";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(viewModel.From, viewModel.Pass);
            try
            {
                smtpClient.Send(message);
                Console.WriteLine("Code send successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Response(HttpStatusCode.OK, "Success");
        }

    }
}
