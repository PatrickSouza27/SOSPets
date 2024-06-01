using Microsoft.AspNetCore.Mvc;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Controllers.User
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly IUserService _userInstance;
        public AddressController(IUserService instance)
            => _userInstance = instance;

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetAddressByUid(string uid)
            => Ok(await _userInstance.GetAddressByUID(uid));

        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateAddress(string uid, [FromBody] AddressViewModelInput addressInput)
        {
            try
            {
                await _userInstance.UpdateAddress(uid, addressInput);
                return Ok("Address Updated!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
