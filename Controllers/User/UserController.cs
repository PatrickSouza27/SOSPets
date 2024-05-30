using Microsoft.AspNetCore.Mvc;
using SOSPets.Domain.ViewModel;
using SOSPets.Extensions;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;
using SOSPets.ViewModel.Session.Edit;

namespace SOSPets.Controllers.User
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
                return NotFound(new ResultDefault<Domain.Models.User>("Usuario Não Encontrado"));

           return Ok(new ResultDefault<Domain.Models.User?>(user));

        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] UserViewModelInput userInput)
        {
            if (!ModelState.IsValid) 
                return BadRequest(new ResultDefault<Domain.Models.User>(ModelState.ExtensionMessage()));
            try
            {
                await _userInstance.AddUserAndAddress(userInput);
                return Created("User created", new ResultDefault<UserViewModelInput>(userInput));
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateUser(string uid,[FromBody] EditUserViewModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDefault<Domain.Models.User>(ModelState.ExtensionMessage()));

            try
            {
                await _userInstance.UpdateUser(uid, user);
                return Ok(new ResultDefault<object>("User Updated!"));

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{uid}")]
        public async Task<IActionResult> DeleteUser(string uid)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultDefault<Domain.Models.User>(ModelState.ExtensionMessage()));

            try
            {
                await _userInstance.DeleteUserAndAddress(uid);
                return Ok(new ResultDefault<object>(new { message = "User Deleted" } ));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
