using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Domain.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public int QuantityPost { get; set; }
        public string Description { get; set; }
        public string UrlPhoto { get; set; }
        public IList<ProfilePet>? ProfilesPet { get; set; }

        public Profile() { }

        public Profile(int id, User user, DateTime dateCreated, int quantityPost, string description, string urlPhoto)
        {
            Id = id;
            User = user;
            DateCreated = dateCreated;
            QuantityPost = quantityPost;
            Description = description;
            UrlPhoto = urlPhoto;
        }
    }
}
