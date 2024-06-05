using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Models.Outputs;
using SOSPets.Services.Interface;
using System.Linq;
using Amazon;
using K4os.Hash.xxHash;
using Microsoft.AspNetCore.Mvc;
using SOSPets.Domain.Models;
using SOSPets.Domain.Models.Enums;
using SOSPets.ViewModel.Session.Querys;
using Profile = SOSPets.Domain.Models.Profile;

namespace SOSPets.Services
{
    public class HomeService : IHomeService
    {
        private readonly DataContextDatabase _dbcontext;
        public HomeService(DataContextDatabase dbcontext) => _dbcontext = dbcontext;
        public async Task<List<HomeOutput>>? GetRegistersHome(string uid, int page, FilterQueryInput? filter)
        {
            var registersList = await _dbcontext.ProfilePets
                .Include(x => x.ProfileUser)
                .Include(x => x.ProfileUser.User)
                .Include(x => x.ProfileUser.User.Address)
                .OrderBy(x => x.DateCreatedProfile)
                .ToListAsync();
            

            if (!string.IsNullOrEmpty(filter?.Size.ToString()))
                registersList = registersList.Where(x => x.SizePet.Equals(filter.Size)).ToList();

            if (!string.IsNullOrEmpty(filter?.Type.ToString()))
                registersList = registersList.Where(x => x.TypePet.Equals(filter.Type)).ToList();

            if (!string.IsNullOrEmpty(filter?.StageLife.ToString()))
                registersList = registersList.Where(x => x.StageLife.Equals(filter.StageLife)).ToList();


            var homeOutPutList = registersList.Select(reg => new HomeOutput(reg.Name, reg.Description, reg?.ProfileUser.UrlPhoto, reg.ProfileUser.User.Name, reg.Id, reg?.UrlPhotoProfile, reg.ProfileUser.User.UID, reg.StageLife, reg.SizePet)).ToList();

            return homeOutPutList.Skip(7 * page).Take(7).ToList();
        }
    }
}