using Paws_API.DomainLayer.Models.Requests;
using Paws_API.DomainLayer.Models.Responses;

namespace Paws_API.DomainLayer.Handlers.EmailHandler
{
    public interface IEmailHandler
    {
        public Task<EmailResponse> SendFosterApplicationEmail(FosterEmailRequest request);
        public Task<EmailResponse> SendVolunteerApplicationEmail(VolunteerEmailRequest request);
    }
}
