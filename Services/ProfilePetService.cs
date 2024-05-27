using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Services
{
    public class ProfilePetService : IProfilePetService
    {
        private readonly DataContextDatabase _dbcontext;
        private readonly IS3Service _s3Service;
        public ProfilePetService(DataContextDatabase dbcontext, IS3Service _serviceS3)
        {
            _dbcontext = dbcontext;
            _s3Service = _serviceS3;
        }
        public async Task AddProfilePetAsync(string uid, ProfilePetViewModelInput profileInput)
        {
            var profileUser = await _dbcontext.Profiles
                                              .FirstOrDefaultAsync(x => x.User.UID == uid);

            if (profileUser is null)
                throw new NullReferenceException("profile user is null - PSX03945");




            var imageUrl = await _s3Service.SaveImageAsync(profileInput.Image, "pets");

            profileInput.ReplaceBase64ForUrl(imageUrl);

            var profilePet = new ProfilePet(profileUser, profileInput);

            if (profileInput.Images != null)
            {
                profileInput.Images.ForEach(x => x.ReplaceBase64ForUrl(x.Image));
                profilePet.AddPhotosList(profileInput.Images);
            }
            await _dbcontext.ProfilePets.AddAsync(profilePet);
            await _dbcontext.SaveChangesAsync();


           
            
            

        }


    }
}
