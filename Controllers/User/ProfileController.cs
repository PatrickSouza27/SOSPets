using Microsoft.AspNetCore.Mvc;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Controllers.User
{
    [ApiController]
    [Route("profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IS3Service _s3Service;

        public ProfileController(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        [HttpPost]
        public async Task<IActionResult> TestingImage([FromBody] ProfileViewModelInput profileInput)
        {
            return Ok(await _s3Service.SaveImageAsync(profileInput.Base64Image, "profile"));
        }
    }
}
