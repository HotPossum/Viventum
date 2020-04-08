using System.Threading.Tasks;

namespace Viventum.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);

        Task SendEmailToAdminAsync(string subject, string htmlMessage);
    }
}
