using SOSPets.Data;

namespace SOSPets.Services
{
    public class ProfileService
    {
        private readonly DataContextDatabase _dbcontext;
        public ProfileService(DataContextDatabase dbcontext)
            => _dbcontext = dbcontext;
    }
}
