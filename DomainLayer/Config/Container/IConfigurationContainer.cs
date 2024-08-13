namespace Paws_API.DomainLayer.Config.Container
{
    public interface IConfigurationContainer
    {
        PetfinderServiceSettings PetfinderServiceSettings { get; }
        EmailClientSettings EmailClientSettings { get; }
    }
}
