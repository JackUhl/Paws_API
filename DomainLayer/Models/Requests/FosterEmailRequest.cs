namespace Paws_API.DomainLayer.Models.Requests
{
    public record FosterEmailRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WhyDoYouWantTo {  get; set; }
        public string WhatAnimalsDoYouHave {  get; set; }
        public string Reference1Name { get; set; }
        public string Reference1Phone { get; set; }
        public string Reference2Name { get; set; }
        public string Reference2Phone { get; set; }
    }
}
