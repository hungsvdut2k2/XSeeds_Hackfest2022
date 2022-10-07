using API.Models.ModelDTOs;

namespace API.Services.IServices
{
    public interface IEmailService
    {
        void sendEmail(EmailDTO request);
    }
}
