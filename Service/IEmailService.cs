using SendMail.Models;

namespace SendMail.Service
{
    public interface IEmailService
    {
        void SendEmail(Email request);
    }
}
