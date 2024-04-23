using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;


namespace SOSPets.Application.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly IUserService _userInstance;
        public AddressController(IUserService userinstance)
            => _userInstance = userinstance;

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetAddressByUID(string uid)
            => Ok(await _userInstance.GetAddressByUID(uid));

        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateAddress(string uid, [FromBody] AddressViewModelInput addressInput)
        {
            try
            {
                await _userInstance.UpdateAddress(uid, addressInput);
                return Ok("endereço atualizado com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            




    }
}
