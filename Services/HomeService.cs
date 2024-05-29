using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Models.Outputs;
using SOSPets.Services.Interface;
using System.Linq;

namespace SOSPets.Services
{
    public class HomeService : IHomeService
    {
        private readonly DataContextDatabase _dbcontext;
        public HomeService(DataContextDatabase dbcontext)=> _dbcontext = dbcontext;
        public async Task<List<HomeOutput>> GetRegistersHome(string uid, int page)
        {
            var city = await _dbcontext.Address.Where(x=> x.User.UID == uid)
                                                     .AsNoTracking()
                                                     .Select(x => x.City)
                                                     .FirstOrDefaultAsync();
            
            var registersList = await _dbcontext.Profiles
                                                    .Include(x => x.ProfilesPet)
                                                    .Include(x => x.User)
                                                    .Include(x => x.User.Address)
                                                    .Where(x => x.User.Address.City == city && x.ProfilesPet != null 
                                                        && x.ProfilesPet.Any())
                                                    .ToListAsync();


            if (registersList == null || registersList.Count == 0)
                throw new Exception("aquiiiii - GXETSQRQWER");

            var homeOutPutList = new List<HomeOutput>();
            foreach(var reg in registersList)
            {
                if (reg.ProfilesPet == null) continue;
                var index = 0;
                for (; index < reg.ProfilesPet.Count; index++)
                {
                    var reg2 = reg.ProfilesPet[index];
                    homeOutPutList.Add(new HomeOutput(reg2.Name, reg2.Description!, reg?.UrlPhoto, reg.User.Name,
                        reg2.Id, reg2?.UrlPhotoProfile));
                }
            }

            return homeOutPutList.Skip(7 * page).Take(7).ToList();


        } 

    }
}
