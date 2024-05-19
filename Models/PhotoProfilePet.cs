using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SOSPets.Domain.Models
{
    public class PhotoProfilePet
    {
        public int Id { get; set; }
        public string UrlPhoto { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ProfilePet ProfilePet { get; set; }
        public DateTime DatePost { get; set; }

        public PhotoProfilePet() { }

        public PhotoProfilePet(string urlPhoto)
        {
            UrlPhoto = urlPhoto;
            DatePost = DateTime.Now;
        }

        public PhotoProfilePet(string urlPhoto, string description) : this (urlPhoto)
        {
            Description = description;
        }

    }
}
