using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using SOSPets.Domain.Models;
using SOSPets.Models.Outputs;
using SOSPets.Services.Interface;

namespace SOSPets.Services
{
    public class MapService : IMapService
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
                { "key", "AIzaSyBkTkicLsrUv7-4JBb_RpErZbB5JNX0-uU" },
                { "address", cep }
            };


            var uri = QueryHelpers.AddQueryString("", queryParams);
            var response = await _httpClient.GetAsync(uri);

            if(response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw new ArgumentNullException("CEP Incorreto");

        }

        public GeolocationOutput GetLatAndLong(string json)
        {
            JObject infoGeoComplet = JObject.Parse(json);

            JObject? location = infoGeoComplet["results"]?.FirstOrDefault()?["geometry"]?["location"] as JObject;


            if(location is not null)
            {
                return new GeolocationOutput((double)location["lat"], (double)location["lng"]);
            }

            throw new ArgumentNullException("CEP Incorreto");
        }
    }
}
