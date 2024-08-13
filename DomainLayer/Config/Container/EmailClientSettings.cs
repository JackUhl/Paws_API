namespace Paws_API.DomainLayer.Config.Container
{
    public record EmailClientSettings
    {
        public string ServerConnectionString { get; set; }
        public string OutputEmailAddress { get; set; }
        public string ServiceEmailUsername { get; set; }
        public string ServiceEmailPassword { get; set; }
    }
}
