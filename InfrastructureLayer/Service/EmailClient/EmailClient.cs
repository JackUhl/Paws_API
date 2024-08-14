using Paws_API.DomainLayer.Config.Container;
using System.Net;
using System.Net.Mail;

namespace Paws_API.InfrastructureLayer.Service.EmailClient
{
    public class EmailClient : IEmailClient
    {
        private SmtpClient _SmtpClient;
        private MailAddress _FromAddress;
        private MailAddress _ToAddress;

        public EmailClient(IConfigurationContainer configurationContainer)
        {
            var settings = configurationContainer.EmailClientSettings;

            _SmtpClient = new SmtpClient(settings.ServerConnectionString, 587)
            {
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(settings.ServiceEmailUsername, settings.ServiceEmailPassword),
                EnableSsl = true,
                Timeout = 10000
            };

            _FromAddress = new MailAddress(settings.ServiceEmailUsername);
            _ToAddress = new MailAddress(settings.OutputEmailAddress);
        }

        public SmtpClient Client => _SmtpClient;
        public MailAddress FromAddress => _FromAddress;
        public MailAddress ToAddress => _ToAddress;
    }
}
