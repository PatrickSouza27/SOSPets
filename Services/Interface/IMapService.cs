using SOSPets.Models.Outputs;

namespace SOSPets.Services.Interface
{
    public interface IMapService
    {
        GeolocationOutput GetLatAndLong(string json);
        Task<string> GetLocation(string cep);
    }
}
