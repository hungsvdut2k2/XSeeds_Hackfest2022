using API.Models.ModelDTOs;
using API.Services.IServices;
using System.Net.Mail;
using System.Net;

namespace API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void sendEmail(EmailDTO request)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetSection("EmailUserName").Value);
            message.To.Add(new MailAddress(request.To));
            message.Subject = request.Subject;
            message.Body = request.Body;
            using (SmtpClient smtp = new SmtpClient(_configuration.GetSection("EmailHost").Value, 587))
            {
                smtp.Credentials = new NetworkCredential(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
