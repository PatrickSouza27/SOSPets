using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;

namespace SOSPets.Services
{
    public class UserService : IUserService
    {
        private readonly DataContextDatabase _dbcontext;
        public UserService(DataContextDatabase dbcontext)
            => _dbcontext = dbcontext;

        public async Task AddUserAndAddress(UserViewModelInput user)
        {
            var userbank = new User(user);
            var address = new Address(user.Address);
            userbank.SetAddress(address);
            await _dbcontext.Users.AddAsync(userbank);
        }

        public async Task<User?> GetUserByUID(string uid)
           => await _dbcontext.Users.Include(x=> x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.UID.Equals(uid));

        public async Task DeleteUser(string uid)
        {
            var user = await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync();

            if(user != null)
            {
                _dbcontext.Users.Remove(user);
                await _dbcontext.SaveChangesAsync();
            }

            throw new ArgumentNullException("user not found");

        }
        public async Task<bool> UpdateUser(string uid, EditUserViewModel userEdit)
        {
            var user = await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UID.Equals(uid));

            if (user != null)
            {
                user.Edit(userEdit);
                await _dbcontext.SaveChangesAsync();
            }

            throw new ArgumentNullException("user not found");
        }

        public async Task UpdateAddress(string uid, AddressViewModelInput userEdit)
        {
            var user = await _dbcontext.Users.Include(x=> x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.UID.Equals(uid));
            if (user != null)
            {
                user.SetAddress(new Address(userEdit));
                await _dbcontext.SaveChangesAsync();
            }
            throw new ArgumentNullException("user not found");
        }

        public async Task<Address?> GetAddressByUID(string uid)
        {
            var userComplet = await _dbcontext.Users.Include(x => x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.UID.Equals(uid));
            
            if (userComplet is not null)
                return userComplet.Address;

            throw new ArgumentNullException("user not found");
        }
    }
}
