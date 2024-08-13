using System.Text.Json;
using Paws_API.InfrastructureLayer.Service.PetfinderService.Client;
using Paws_API.DomainLayer.Config.Container;
using Paws_API.DomainLayer.Models.Responses;

namespace Paws_API.InfrastructureLayer.Service.PetfinderService
{
    public class PetfinderService : IPetfinderService
    {
        private HttpClient _petfinderClient;
        private IConfigurationContainer _configurationContainer;

        public PetfinderService(IPetfinderHttpClient petfinderHttpClient, IConfigurationContainer configurationContainer) 
        {
            _petfinderClient = petfinderHttpClient.Client;
            _configurationContainer = configurationContainer;
        }

        public async Task<PetfinderResponse> GetPetfinderAnimals()
        {
            var url = new UriBuilder(_configurationContainer.PetfinderServiceSettings.BaseUrl);
            url.Path = _configurationContainer.PetfinderServiceSettings.Endpoints.Animals;
            url.Query = _configurationContainer.PetfinderServiceSettings.Params.OrganizationParam;

            var response = await _petfinderClient.GetAsync(url.Uri.AbsoluteUri);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<PetfinderResponse>(responseContent);
                return responseObject;
            }
            else
            {
                throw new Exception("Unable to retrieve data from Petfinder");
            }
        }
    }
}
