using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Domain.ViewModel;
using SOSPets.Extensions;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;


namespace SOSPets.Application.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userInstance;
        public UserController(IUserService userinstance)
            => _userInstance = userinstance;

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetUser(string uid)
        {

           var user = await _userInstance.GetUserByUID(uid);

           if (user == null)
                return NotFound(new ResultDefault<User>("Usuario Não Encontrado"));

           return Ok(new ResultDefault<User?>(user));

        }
            
        


        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] UserViewModelInput userInput)
        {
            if (!ModelState.IsValid) 
                return BadRequest(new ResultDefault<User>(ModelState.ExtensionMessage()));
            try
            {
                await _userInstance.AddUserAndAddress(userInput);
                return Created("Usuario Criado com sucesso!", userInput);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
