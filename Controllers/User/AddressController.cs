using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SOSPets.Data.Repository;
using SOSPets.Data.Repository.Interfaces;
using SOSPets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSPets.Application.Controllers
{
    [ApiController]
    internal class AddressController : ControllerBase
    {
        private readonly IDefaultRepository<Address> _repository;
        public AddressController(IDefaultRepository<Address> addressRepository)
            => _repository = addressRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await _repository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Address address)
        {
            return Ok(address.Add(_repository));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Address address)
        {
            return Ok(address.Update(_repository));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int Id)
        {
            var address = await _repository.GetAllAsync();
            address.Remove(address.Where(x => x.Id == Id).First());
            return Ok("Usuario Excluido");
        }

    }
}
