using Newtonsoft.Json;
using SOSPets.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SOSPets.ViewModel.Session
{
    public class ProfilePetViewModelInput
    {
        [Required(ErrorMessage = "Nome Obrigatorio")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string? Image { get; set; }
        public TypePetEnum Type { get; set; }
        public SizePetEnum Size { get; set; }
        public StageLifeEnum Stage { get; set; }

        public List<PhotosProfileViewModelInput>? Images { get; set; }

        public ProfilePetViewModelInput() { }
        public void ReplaceBase64ForUrl(string url)
            => Image = url;
    }
}
