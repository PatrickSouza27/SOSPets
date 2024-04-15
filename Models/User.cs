using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UID { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public User() { }

        public User(string name, string lastName, string cpf, DateTime birthday, string uid)
        {
            Name = name;
            LastName = lastName;
            UID = uid;
            Cpf = cpf;
            Birthday = birthday;
        }

        public User(string name, string lastName, string cpf, DateTime birthday, string uid, Address address) : this (name, lastName, cpf, birthday, uid)
        {
            Address = address;
        }

        public void SetAddress(Address address) => Address = address;

    }
}
