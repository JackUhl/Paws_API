using Paws_API.DomainLayer.Models.Responses;

namespace Paws_API.InfrastructureLayer.Service.PetfinderService
{
    public interface IPetfinderService
    {
        Task<PetfinderResponse> GetPetfinderAnimals();
    }
}
