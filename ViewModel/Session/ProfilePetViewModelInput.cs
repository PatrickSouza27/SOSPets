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
        [JsonProperty("type")]
        public TypePetEnum TypePet { get; set; }
        [JsonProperty("size")]
        public SizePetEnum SizePet { get; set; }
        [JsonProperty("stage")]
        public StageLifeEnum StageLife { get; set; }

        public List<PhotosProfileViewModelInput>? Images { get; set; }

        public ProfilePetViewModelInput() { }
        public void ReplaceBase64ForUrl(string url)
            => Image = url;
    }
}
