using SOSPets.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Domain.Models
{
    public class ProfilePet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UrlPhotoProfile { get; set; }
        public string Race { get; set; }
        public TypePetEnum TypePet { get; set; }
        public SizePetEnum SizePet { get; set; }
        public StageLifeEnum StageLife { get; set; }
        public DateTime DateCretedProfile { get; set; }
        public DateTime LastUpdate { get; set; }
        public Profile ProfileUser { get; set; }
        public IList<PhotoProfilePet>? PhotosProfilePet { get; set; }
    }
}
