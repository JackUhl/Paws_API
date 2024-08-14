namespace Paws_API.DomainLayer.Models.Requests
{
    public record VolunteerEmailRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone {  get; set; }
        public required VolunteerOptions VolunteerOptions { get; set; }
    }

    public record VolunteerOptions
    {
        public bool Transport { get; set; }
        public bool EventSetUp { get; set; }
        public bool Fundraising { get; set; }
        public bool Photography { get; set; }
        public bool Grooming { get; set; }
        public bool Training { get; set; }
    }
}
