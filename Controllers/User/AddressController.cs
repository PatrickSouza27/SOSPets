using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.ViewModel.Session;


namespace SOSPets.Application.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        private readonly DataContextDatabase _dbcontext;
        public AddressController(DataContextDatabase dbcontext)
            => _dbcontext = dbcontext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _dbcontext.Address.AsNoTracking().ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddressViewModelInput addressInput)
        {
            _dbcontext.Address.Add(new Address(addressInput));
            await _dbcontext.SaveChangesAsync();
            return Created("Salvo com Sucesso!", addressInput);
        }

        

    }
}
