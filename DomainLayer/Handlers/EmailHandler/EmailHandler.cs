using Paws_API.DomainLayer.Handlers.PetfinderHandler;
using Paws_API.DomainLayer.Models.Requests;
using Paws_API.DomainLayer.Models.Responses;
using Paws_API.InfrastructureLayer.Service.EmailClient;
using Paws_API.InfrastructureLayer.Service.PetfinderService;
using System.Net.Mail;

namespace Paws_API.DomainLayer.Handlers.EmailHandler
{
    public class EmailHandler : IEmailHandler
    {
        ILogger _logger;
        IEmailClient _emailClient;

        public EmailHandler(ILogger<EmailHandler> logger, IEmailClient emailClient)
        {
            _logger = logger;
            _emailClient = emailClient;
        }

        public async Task<EmailResponse> SendFosterApplicationEmail(FosterEmailRequest request)
        {
            try
            {
                var newEmail = new MailMessage(_emailClient.FromAddress, _emailClient.ToAddress)
                {
                    Subject = "New Foster Application",
                    SubjectEncoding = System.Text.Encoding.UTF8,

                    Body = $"""
                        Applicant
                        Name: {request.FirstName} {request.LastName}
                        Phone: {request.Phone}
                        Email: {request.Email}

                        Why They Want To Foster:
                        {request.WhyDoYouWantTo}
                        
                        What Animals They Have:
                        {request.WhatAnimalsDoYouHave}

                        Reference 1: {request.Reference1Name}- {request.Reference1Phone}
                        Reference 2: {request.Reference2Name}- {request.Reference2Phone}
                    """,
                    BodyEncoding = System.Text.Encoding.UTF8,
                    IsBodyHtml = false,
                };

                _emailClient.Client.Send(newEmail);
                return new EmailResponse() 
                {
                    Success = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
