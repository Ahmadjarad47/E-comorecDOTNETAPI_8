using E_commorec.core.Entity;

namespace E_commorec.core.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailModel email);
    }
}
