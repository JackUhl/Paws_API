using Paws_API.DomainLayer.Config.Container;
using System.Net.Http.Headers;

namespace Paws_API.InfrastructureLayer.Service.PetfinderService.Client
{
    public class PetfinderHttpClient : IPetfinderHttpClient
    {
        private HttpClient _httpClient;

        public PetfinderHttpClient(IConfigurationContainer configurationContainer)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configurationContainer.PetfinderServiceSettings.Secrets.BearerToken);
        }

        public HttpClient Client => _httpClient;
    }
}
