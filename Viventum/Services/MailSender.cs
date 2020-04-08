using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Viventum.Options;
using Viventum.Services.Interfaces;

namespace Viventum.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderSettings _emailSenderSettings;

        public EmailSender(
            EmailSenderSettings emailSenderSettings)
        {
            _emailSenderSettings = emailSenderSettings;
        }

        // Use our configuration to send the email by using SmtpClient
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(_emailSenderSettings.Host, _emailSenderSettings.Port)
            {
                Credentials = new NetworkCredential(
                    _emailSenderSettings.UserName,
                    _emailSenderSettings.Password,
                    _emailSenderSettings.Domain),
                EnableSsl = _emailSenderSettings.EnableSSL
            };

            return client.SendMailAsync(
                new MailMessage(_emailSenderSettings.From, email, subject, htmlMessage) { IsBodyHtml = true }
            );
        }

        public Task SendEmailToAdminAsync(string subject, string htmlMessage)
        {
            return SendEmailAsync(_emailSenderSettings.AdminEmail, subject, htmlMessage);
        }
    }
}
