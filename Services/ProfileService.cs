using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Services
{
    public class ProfileService
    {
        private readonly DataContextDatabase _dbcontext;
        private readonly IS3Service _s3Service;
        public ProfileService(DataContextDatabase dbcontext, IS3Service _serviceS3)
        {
            _dbcontext = dbcontext;
            _s3Service = _serviceS3;

        }
            
        public async Task<Profile> GetProfile()
        {
            var profile = _dbcontext.Profiles.Where()
        }
        public async Task AddProfile(ProfileViewModelInput modelInputProfile)
        {

        }

        public Task<> UpdateProfile()
        {

        }
    }
}
