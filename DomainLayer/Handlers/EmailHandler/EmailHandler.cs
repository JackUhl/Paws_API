using Paws_API.DomainLayer.Models.Requests;
using Paws_API.DomainLayer.Models.Responses;
using Paws_API.InfrastructureLayer.Service.EmailClient;
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
                var fosterApplicationEmail = new MailMessage(_emailClient.FromAddress, _emailClient.ToAddress)
                {
                    Subject = "New Foster Application",
                    SubjectEncoding = System.Text.Encoding.UTF8,

                    Body = $"""
                        Applicant Name: {request.FirstName} {request.LastName}
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

                await _emailClient.Client.SendMailAsync(fosterApplicationEmail);
                
                return new EmailResponse() 
                {
                    Success = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException?? new Exception());
            }
        }

        public async Task<EmailResponse> SendVolunteerApplicationEmail(VolunteerEmailRequest request)
        {
            try
            {
                var volunteerApplicationEmail = new MailMessage(_emailClient.FromAddress, _emailClient.ToAddress)
                {
                    Subject = "New Volunteer Application",
                    SubjectEncoding = System.Text.Encoding.UTF8,

                    Body = $"""
                        Applicant Name: {request.FirstName} {request.LastName}
                        Phone: {request.Phone}
                        Email: {request.Email}

                        What they can assit with:
                        {(request.VolunteerOptions.Transport? "Transport": "")}
                        {(request.VolunteerOptions.EventSetUp ? "Event Set Up" : "")}
                        {(request.VolunteerOptions.Fundraising ? "Fundraising" : "")}
                        {(request.VolunteerOptions.Photography ? "Photography" : "")}
                        {(request.VolunteerOptions.Grooming ? "Grooming" : "")}
                        {(request.VolunteerOptions.Training ? "Training" : "")}
                    """,
                    BodyEncoding = System.Text.Encoding.UTF8,

                    IsBodyHtml = false,
                };

                await _emailClient.Client.SendMailAsync(volunteerApplicationEmail);
                
                return new EmailResponse()
                {
                    Success = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException ?? new Exception());
            }
        }

        public async Task<EmailResponse> SendAdoptionApplicationEmail(AdoptionEmailRequest request)
        {
            try
            {
                var adoptionApplicationEmail = new MailMessage(_emailClient.FromAddress, _emailClient.ToAddress)
                {
                    Subject = $"New Adoption Application - {request.PetApplyingFor}",
                    SubjectEncoding = System.Text.Encoding.UTF8,

                    Body = $"""
                        Application for {request.PetApplyingFor}:

                        Applicant Name: {request.FirstName} {request.LastName}
                        Phone: {request.Phone}
                        Email: {request.Email}

                        Address Line 1: {request.AddressLineOne}
                        Address Line 2: {request.AddressLineTwo}
                        City: {request.City}
                        State: {request.State}
                        Zip: {request.Zip}

                        What pets they currently have:
                        {request.CurrentPets}

                        Current household members:
                        {request.HouseholdMembers}

                        Landlord Info:
                        {request.LandlordInfo}

                        Reference 1: {request.Reference1Name}- {request.Reference1Phone}
                        Reference 2: {request.Reference2Name}- {request.Reference2Phone}
                        Reference 3: {request.Reference3Name}- {request.Reference3Phone}

                        Vet Name: {request.VetName}
                        Vet Phone: {request.VetPhone}
                    """,
                    BodyEncoding = System.Text.Encoding.UTF8,

                    IsBodyHtml = false,
                };

                await _emailClient.Client.SendMailAsync(adoptionApplicationEmail);

                return new EmailResponse()
                {
                    Success = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException ?? new Exception());
            }
        }
    }
}
