using SOSPets.ViewModel.Session;
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
        public string Email { get; set; }
        public Address Address { get; set; }
        public User() { }

        public User(UserViewModelInput user)
        {
            Name = user.Name;
            LastName = user.LastName;
            UID = user.UID;
            Email = user.Email;
        }
        public void SetAddress(Address address) => Address = address;
        public void Edit(EditUserViewModel userEdit)
        {
            Name = userEdit.Name;
            LastName = userEdit.LastName;
        }

    }
}
