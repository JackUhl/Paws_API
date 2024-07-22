using Paws_API.DomainLayer.Responses;

namespace Paws_API.InfrastructureLayer.Service.PetfinderService
{
    public interface IPetfinderService
    {
        Task<PetfinderResponse> GetPetfinderAnimals();
    }
}
