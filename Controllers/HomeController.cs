using Microsoft.AspNetCore.Mvc;
using SOSPets.Services;
using SOSPets.Services.Interface;

namespace SOSPets.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("{uid}")]
        public async Task<IActionResult> GetProfilesPetRegion(string uid, [FromQuery] int qtdtake, [FromQuery] int qtdskip)
        {
            return Ok(await _homeService.GetRegistersHome(uid, qtdtake, qtdskip));
        } 
    }
}
