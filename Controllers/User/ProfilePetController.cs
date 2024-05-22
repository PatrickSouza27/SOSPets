using Microsoft.AspNetCore.Mvc;
using SOSPets.Services;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Controllers.User
{
    [ApiController]
    [Route("profilepet")]
    public class ProfilePetController : ControllerBase
    {
        private readonly IProfilePetService _profilePetService;

        public ProfilePetController(IProfilePetService profilePetService) => _profilePetService = profilePetService; 
        
        [HttpPost("{uid}")]
        public async Task<IActionResult> AddProfilePet(string uid, [FromBody] ProfilePetViewModelInput profilePetInput)
        {
            try
            {
                await _profilePetService.AddProfilePetAsync(uid, profilePetInput);

                return Ok("profile pet adicionado");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("teste/{uid}")]
        public async Task<IActionResult> AddImagensTesting(string uid, [FromBody] ProfilePetViewModelInput profilePetInput)
        {
            try
            {

                await _profilePetService.AddProfilePetAsync(uid, profilePetInput);

                return Ok("Foto Adicionado com sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
