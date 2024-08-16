using Microsoft.Extensions.Options;

namespace Paws_API.DomainLayer.Config.Container
{
    public class ConfigurationContainer : IConfigurationContainer
    {
        public PetfinderServiceSettings PetfinderServiceSettings { get; }
        public EmailClientSettings EmailClientSettings { get; }

        public ConfigurationContainer(
            IOptions<PetfinderServiceSettings> petfinderServiceSettings,
            IOptions<EmailClientSettings> emailClientSettings
        )
        {
            PetfinderServiceSettings = petfinderServiceSettings.Value;
            EmailClientSettings = emailClientSettings.Value;
        }
    }
}
