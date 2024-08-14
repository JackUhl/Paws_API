namespace Paws_API.DomainLayer.Models.Requests
{
    public record FosterEmailRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public required string WhyDoYouWantTo {  get; set; }
        public required string WhatAnimalsDoYouHave {  get; set; }
        public required string Reference1Name { get; set; }
        public required string Reference1Phone { get; set; }
        public required string Reference2Name { get; set; }
        public required string Reference2Phone { get; set; }
    }
}
