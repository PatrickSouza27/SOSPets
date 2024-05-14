using SOSPets.Domain.Models;
using SOSPets.ViewModel.Session.Edit;

namespace SOSPets.Services.Interface
{
    public interface IProfileService
    {
        Task AddProfileAsync(string uid);
        Task<Profile?> GetProfileAsync(string uid);
        Task<Profile> UpdateProfileAsync(EditProfileViewModel editProfile, string uid);
    }
}
