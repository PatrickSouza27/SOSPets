using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Models.Outputs;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Services
{
    public class ProfilePetService : IProfilePetService
    {
        private readonly DataContextDatabase _dbcontext;
        private readonly IS3Service _s3Service;
        public ProfilePetService(DataContextDatabase instanceDb, IS3Service serviceS3)
        {
            _dbcontext = instanceDb;
            _s3Service = serviceS3;
        }
        private async Task<List<ProfilePet>> GetListProfilesPet()
        {
            var profilePet =  await _dbcontext.ProfilePets.Include(x => x.ProfileUser)
                .Include(x => x.ProfileUser.User)
                .Include(x=> x.ProfileUser.User.Address)
                .Include(x => x.PhotosProfilePet).ToListAsync();

            if(profilePet is null)
                throw new ArgumentNullException(nameof(profilePet));

            return profilePet;
        }
        public async Task AddProfilePetAsync(string uid, ProfilePetViewModelInput profileInput)
        {
            var profileUser = await _dbcontext.Profiles
                                              .FirstOrDefaultAsync(x => x.User.UID == uid);

            if (profileUser is null)
                throw new NullReferenceException("profile user is null - PSX03945");

            if (profileInput.Image != null)
            {
                var imageUrl = await _s3Service.SaveImageAsync(profileInput.Image, "pets");

                profileInput.ReplaceBase64ForUrl(imageUrl);
            }

            var profilePet = new ProfilePet(profileUser, profileInput);

            if (profileInput.Images != null)
            {
                foreach(var image in profileInput.Images){
                    var imagesUrl = await _s3Service.SaveImageAsync(image.Image, "pets");
                    image.ReplaceBase64ForUrl(imagesUrl);
                }
                profilePet.AddPhotosList(profileInput.Images);
            }
            await _dbcontext.ProfilePets.AddAsync(profilePet);
            await _dbcontext.SaveChangesAsync();
         

        }
        public async Task<List<AddressGeoOutput>?> GetGeoAddressPetsAsync(string uid)
        {
            var profilePet = await GetListProfilesPet();
            var profilePetList = profilePet
                                            .Where(x => x.ProfileUser.User.UID != uid)
                                            .Select(x => x.ProfileUser.User)
                                            .DistinctBy(x => x.UID)
                                            .ToList();
            
            var addressList = profilePetList.Select(x=> new AddressGeoOutput(x.UID, x.Address.Latitude, x.Address.Longitude)).ToList();
            
            return addressList;
        }
        public async Task<ProfilePetByIdOutput> GetProfilePetByIdAsync(int id)
        {

            var profilePetList = await GetListProfilesPet();
            var profilePet = profilePetList.FirstOrDefault(x=> x.Id == id) ?? throw new ArgumentNullException(nameof(id));
            
            
            var imageList = new List<string>();
            if (profilePet.PhotosProfilePet != null)
            {
                imageList = profilePet.PhotosProfilePet.Select(x => x.UrlPhoto).ToList();
            }
            
            var profilePetOutput = new ProfilePetByIdOutput(profilePet.ProfileUser.User.UID, profilePet.ProfileUser.User.Name, profilePet.Name, profilePet.SizePet, profilePet.StageLife,
            profilePet.TypePet, profilePet?.Description, profilePet?.UrlPhotoProfile, imageList, profilePet.ProfileUser.User.Address.Latitude, profilePet.ProfileUser.User.Address.Longitude);
            
            return profilePetOutput;
        }
        public async Task DeleteProfilePetAsync(int id)
        {
            var profilePet = await _dbcontext.ProfilePets.Include(x=> x.PhotosProfilePet).FirstOrDefaultAsync(x => x.Id == id);
            
            
            
            if(profilePet is null)
                throw new ArgumentNullException(nameof(profilePet));
            
            
            _dbcontext.ProfilePets.Remove(profilePet);
            
            await _dbcontext.SaveChangesAsync();

        }


    }
}
