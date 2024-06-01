using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json.Linq;
using SOSPets.Domain.Models;
using SOSPets.Models;
using SOSPets.Models.Outputs;
using SOSPets.Services.Interface;

namespace SOSPets.Services
{
    public class MapService : IMapService
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/json")
        };

        public async Task<string> GetLocation(string cep)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "key", "AIzaSyBkTkicLsrUv7-4JBb_RpErZbB5JNX0-uU" },
                { "address", cep }
            };


            var uri = QueryHelpers.AddQueryString("", queryParams!);
            var response = await _httpClient.GetAsync(uri);

            if(response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            throw new ArgumentNullException(nameof(cep));

        }

        public GeolocationOutput GetLatAndLong(string json)
        {
            var infoGeoComplete = JObject.Parse(json);

            var location = infoGeoComplete["results"]?.FirstOrDefault()?["geometry"]?["location"] as JObject ?? throw new NullReferenceException("CEP INCORRETO");
            
            if(double.TryParse((string?)location["lat"], out var lat) && double.TryParse(((string?)location["lng"]), out var lng))
                return new GeolocationOutput(lat, lng);
            
            throw new ArgumentNullException(nameof(json));

        }

    }
}
