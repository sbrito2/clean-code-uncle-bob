
using API.Domain.Projections.Email;

namespace API.Domain.Services
{
    public interface IEmailService
    {
        void SendCustomerEmail(EmailProjectionModel customerEmail);

        void Send(string subject, string message, bool isBodyHtml = false);
    }
}