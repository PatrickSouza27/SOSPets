using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Models.Outputs;
using SOSPets.Services;
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

        [HttpGet("teste/{cep}")]
        public async Task<IActionResult> GetLatLong(string cep)
        {
            var testing = new MapService();
            try
            {
                var response = await testing.GetLocation(cep);
                return Ok(testing.GetLatAndLong(response));


            } catch(Exception ex)
            {
                return BadRequest("error");
            }

            


            
        }
    }
}
