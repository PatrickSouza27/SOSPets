using SOSPets.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public async Task<bool> Add(IDefaultRepository<Address> repository) => await repository.CreateAsync(this);
        public async Task<bool> Update(IDefaultRepository<Address> repository) => await repository.UpdateAsync(this);
        public async Task<bool> Delete(IDefaultRepository<Address> repository) => await repository.DeleteAsync(this.Id);
        

    }
}
