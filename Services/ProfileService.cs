using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;
using SOSPets.ViewModel.Session.Edit;

namespace SOSPets.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DataContextDatabase _dbcontext;
        private readonly IS3Service _s3Service;
        public ProfileService(DataContextDatabase dbcontext, IS3Service _serviceS3)
        {
            _dbcontext = dbcontext;
            _s3Service = _serviceS3;
        }
            
        public async Task<Profile?> GetProfileAsync(string uid)
            => await _dbcontext.Profiles.Include(x => x.User).Include(x => x.User.Address).Where(x => x.User.UID == uid).FirstOrDefaultAsync();
        
        public async Task AddProfileAsync(string uid)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.UID == uid);

            if (user == null)
                throw new NullReferenceException("user not found");

            var profile = new Profile(user);

            _dbcontext.Profiles.Add(profile);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Profile> UpdateProfileAsync(EditProfileViewModel editProfile, string uid)
        {
            var profile = await _dbcontext.Profiles
                                .Include(x => x.User)
                                .Include(x=> x.User.Address)
                                .FirstOrDefaultAsync(x => x.User != null && x.User.UID == uid);


            if (profile == null)
                throw new NullReferenceException("profile not found");

            var imageUrl = await _s3Service.SaveImageAsync(editProfile.Image, "profile");

            editProfile.ReplaceBase64ForUrl(imageUrl);

            profile.UpdateRegisterProfile(editProfile);
            
            _dbcontext.Profiles.Update(profile);

            await _dbcontext.SaveChangesAsync();

            return profile;
            
        }
    }
}
