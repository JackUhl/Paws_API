namespace Paws_API.DomainLayer.Config.Container
{
    public record EmailClientSettings
    {
        public required string ServerConnectionString { get; set; }
        public required string OutputEmailAddress { get; set; }
        public required string ServiceEmailUsername { get; set; }
        public required string ServiceEmailPassword { get; set; }
    }
}
