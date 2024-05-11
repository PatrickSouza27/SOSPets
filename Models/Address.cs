
using SOSPets.ViewModel.Session;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace SOSPets.Domain.Models
{
    public class Address
    {
       
        public int Id { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }   

        [JsonIgnore]
        public User User { get; set; }
        public Address() { }
        public Address(AddressViewModelInput addressViewModelInput)
            => SetValues(addressViewModelInput);

        public void SetValues(AddressViewModelInput addressViewModelInput)
        {
            Street = addressViewModelInput.Street;
            PostalCode = addressViewModelInput.PostalCode;
            Neighborhood = addressViewModelInput.Neighborhood;
            Complement = addressViewModelInput.Complement;
            Number = addressViewModelInput.Number;
            City = addressViewModelInput.City;
        }
        
        public void SetGeoLocation(double  latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
