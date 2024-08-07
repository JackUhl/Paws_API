using Paws_API.DomainLayer.Responses;
using Paws_API.InfrastructureLayer.Service.PetfinderService;

namespace Paws_API.DomainLayer.Handlers.PetfinderHandler
{
    public class AdoptablePetsHandler : IAdoptablePetsHandler
    {
        ILogger _logger;
        IPetfinderService _petfinderService;

        public AdoptablePetsHandler(ILogger<AdoptablePetsHandler> logger, IPetfinderService petfinderService)
        {
            _logger = logger;
            _petfinderService = petfinderService;
        }

        public async Task<PetfinderResponse> GetPetfinderAnimals()
        {
            try
            {
                var animals = await _petfinderService.GetPetfinderAnimals();
                return animals;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
