using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Domain.Models
{
    public class PhotoProfilePet
    {
        public int Id { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }
        public ProfilePet ProfilePet { get; set; }
        public DateTime DatePost { get; set; }
    }
}
