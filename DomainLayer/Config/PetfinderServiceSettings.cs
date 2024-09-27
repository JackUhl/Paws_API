namespace Paws_API.DomainLayer.Config
{
    public class PetfinderServiceSettings
    {
        public string BaseUrl { get; set; }
        public PetfinderServiceEndpoints Endpoints { get; set; }
        public PetfinderServiceParams Params { get; set; }
        public PetfinderServiceSecrets Secrets { get; set; }
    }

    public class PetfinderServiceEndpoints
    {
        public string Animals { get; set; }
    }

    public class PetfinderServiceParams
    {
        public string OrganizationParam { get; set; }
        public string LimitParam { get; set; }
    }

    public class PetfinderServiceSecrets
    {
        public string BearerToken { get; set; }
    }
}
