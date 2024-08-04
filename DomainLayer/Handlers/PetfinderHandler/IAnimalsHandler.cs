using Paws_API.DomainLayer.Responses;

namespace Paws_API.DomainLayer.Handlers.PetfinderHandler
{
    public interface IAnimalsHandler
    {
        public Task<PetfinderResponse> GetPetfinderAnimals();
    }
}
