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
        
        [HttpGet]
        public async Task<IActionResult> GetProfilePetById([FromQuery] int id)
        {
            try
            {
                return Ok(await _profilePetService.GetProfilePetByIdAsync(id));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
