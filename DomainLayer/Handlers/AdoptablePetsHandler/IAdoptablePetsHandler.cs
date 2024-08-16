using Paws_API.DomainLayer.Models.Responses;

namespace Paws_API.DomainLayer.Handlers.PetfinderHandler
{
    public interface IAdoptablePetsHandler
    {
        public Task<PetfinderResponse> GetPetfinderAnimals();
    }
}
