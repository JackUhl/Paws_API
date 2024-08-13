namespace Paws_API.DomainLayer.Models.Responses
{
    public record EmailResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
