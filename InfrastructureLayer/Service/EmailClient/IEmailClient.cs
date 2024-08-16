using System.Net.Mail;

namespace Paws_API.InfrastructureLayer.Service.EmailClient
{
    public interface IEmailClient
    {
        SmtpClient Client { get; }
        MailAddress FromAddress { get; }
        MailAddress ToAddress { get; }
    }
}
