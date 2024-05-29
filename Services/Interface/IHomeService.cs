using SOSPets.Models.Outputs;

namespace SOSPets.Services.Interface
{
    public interface IHomeService
    {
        Task<List<HomeOutput>> GetRegistersHome(string uid, int page);
    }
}
