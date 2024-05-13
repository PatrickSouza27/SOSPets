using System.ComponentModel.DataAnnotations;

namespace SOSPets.ViewModel.Session
{
    public class ProfileViewModelInput
    {
        [Required(ErrorMessage = "Imagem não encontrada")]
        public string Base64Image { get; set; }
    }
}
