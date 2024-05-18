using SOSPets.ViewModel.Session;

namespace SOSPets.Services.Interface
{
    public interface IProfilePetService
    {
         Task AddProfilePetAsync(string uid, ProfilePetViewModelInput profileInput);
    }
}
