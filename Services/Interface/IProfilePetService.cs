using SOSPets.Domain.Models;
using SOSPets.Models.Outputs;
using SOSPets.ViewModel.Session;

namespace SOSPets.Services.Interface
{
    public interface IProfilePetService
    {
         Task AddProfilePetAsync(string uid, ProfilePetViewModelInput profileInput);
         Task<ProfilePetByIdOutput> GetProfilePetByIdAsync(int id);
         Task DeleteProfilePetAsync(int id);
         Task<List<AddressGeoOutput>?> GetGeoAddressPetsAsync(string uid);
    }
}
