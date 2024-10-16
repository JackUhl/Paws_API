namespace Paws_API.DomainLayer.Models.Requests
{
    public record AdoptionEmailRequest
    {
        public required string PetApplyingFor { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string AddressLineOne { get; set; }
        public required string AddressLineTwo { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string Zip { get; set; }
        public required string CurrentPets { get; set; }
        public required string HouseholdMembers { get; set; }
        public required string LandlordInfo { get; set; }
        public required string Reference1Name { get; set; }
        public required string Reference1Phone { get; set; }
        public required string Reference2Name { get; set; }
        public required string Reference2Phone { get; set; }
        public required string Reference3Name { get; set; }
        public required string Reference3Phone { get; set; }
        public required string VetName { get; set; }
        public required string VetPhone { get; set; }
    }
}
