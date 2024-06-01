using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
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
        [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 3765ms")]
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
        
        [HttpGet("mapping/{uid}")]
        public async Task<IActionResult> GetProfilePetById(string uid)
        {
            try
            {
                return Ok(await _profilePetService.GetGeoAddressPetsAsync(uid));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("{uid}")]
        public async Task<IActionResult> AddProfilePet(string uid, [FromBody] ProfilePetViewModelInput profilePetInput)
        {
            try
            {
                await _profilePetService.AddProfilePetAsync(uid, profilePetInput);

                return Ok("Profile Pet Added!");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete]
        [SuppressMessage("ReSharper.DPA", "DPA0011: High execution time of MVC action", MessageId = "time: 3495ms")]
        public async Task<IActionResult> DeleteProfilePet([FromQuery] int id)
        {
            try
            {
                await _profilePetService.DeleteProfilePetAsync(id);

                return Ok("Profile Pet Deleted!");

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
