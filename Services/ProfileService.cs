using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;

namespace SOSPets.Services
{
    public class ProfileService
    {
        private readonly DataContextDatabase _dbcontext;
        public ProfileService(DataContextDatabase dbcontext)
            => _dbcontext = dbcontext;

        //public async Task<Profile> GetProfile()
        //{
        //    var profile = _dbcontext.Profiles.Where()
        //}
        //public async Task AddProfile()
        //{

        //}

        //public Task<> UpdateProfile()
        //{

        //}
    }
}
