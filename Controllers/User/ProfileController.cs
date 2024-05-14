using Microsoft.AspNetCore.Mvc;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;
using SOSPets.ViewModel.Session.Edit;

namespace SOSPets.Controllers.User
{
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetProfile(string uid)
        {
            return Ok(await _profileService.GetProfileAsync(uid));
        }

        [HttpPost("{uid}")]
        public async Task<IActionResult> AddProfile(string uid)
        {
            try
            {
                await _profileService.AddProfileAsync(uid);
                return Ok("Adicionado");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateProfile(string uid, [FromBody] EditProfileViewModel profileInput)
        {
            try
            {               
                return Ok(await _profileService.UpdateProfileAsync(profileInput, uid));

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
