using Microsoft.AspNetCore.WebUtilities;
using SOSPets.Domain.Models;
using SOSPets.Models.Outputs;

namespace SOSPets.Services
{
    public class MapService
    {
        private readonly HttpClient _httpClient;
        public MapService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new("https://maps.googleapis.com/maps/api/geocode/json")
            };
        }
        public async Task<string> GetLocation(string cep)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "key", "AIzaSyDHv5TcmpnA3xi12l9p-ol1GD-URciOaqk" },
                { "address", cep }
            };


            var uri = QueryHelpers.AddQueryString("", queryParams);
            var response = await _httpClient.GetAsync(uri);

            if(response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw new ArgumentNullException("Cep Invalido");


        }
    }
}
