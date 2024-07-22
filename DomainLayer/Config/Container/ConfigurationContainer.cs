using Microsoft.Extensions.Options;

namespace Paws_API.DomainLayer.Config.Container
{
    public class ConfigurationContainer : IConfigurationContainer
    {
        public PetfinderServiceSettings PetfinderServiceSettings { get; }

        public ConfigurationContainer(
            IOptions<PetfinderServiceSettings> petfinderServiceSettings
        )
        {
            PetfinderServiceSettings = petfinderServiceSettings.Value;
        }
    }
}
