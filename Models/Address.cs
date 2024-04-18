
using SOSPets.ViewModel.Session;

using System.ComponentModel.DataAnnotations.Schema;


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
        public Address() { }
        public Address(int id)
        {
            Id = id;
        }
        public Address(string street, string postalCode, string neighborhood, string complement, string number, string city)
        {
            Street = street;
            PostalCode = postalCode;
            Neighborhood = neighborhood;
            Complement = complement;
            Number = number;
            City = city;
        }

        public Address(AddressViewModelInput addressViewModelInput)
        {
            Street = addressViewModelInput.Street;
            PostalCode = addressViewModelInput.PostalCode;
            Neighborhood = addressViewModelInput.Neighborhood;
            Complement = addressViewModelInput.Complement;
            Number = addressViewModelInput.Number;
            City = addressViewModelInput.City;
        }
        

    }
}
