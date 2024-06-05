using Microsoft.AspNetCore.Mvc;
using SOSPets.Models.Outputs;
using SOSPets.ViewModel.Session.Querys;

namespace SOSPets.Services.Interface
{
    public interface IHomeService
    {
        Task<List<HomeOutput>>? GetRegistersHome(string uid, int page, FilterQueryInput? filter);
    }
}
