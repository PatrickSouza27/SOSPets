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
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User?> GetUserByUID(string uid)
           => await _dbcontext.Users.Include(x=> x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.UID.Equals(uid));

        public async Task DeleteUserAndAddress(string uid)
        {
            var user = await _dbcontext.Users.Include(x=> x.Address).AsNoTracking().FirstOrDefaultAsync(x=> x.UID.Equals(uid));
            
            if(user != null)
            {
                var address = user.Address;              
                _dbcontext.Users.Remove(user);
                _dbcontext.Address.Remove(address);
                await _dbcontext.SaveChangesAsync();
                return;
            }

            throw new ArgumentNullException("user not found");

        }
        public async Task UpdateUser(string uid, EditUserViewModel userEdit)
        {
            var user = await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UID.Equals(uid));

            if (user != null)
            {
                user.Edit(userEdit);
                _dbcontext.Users.Update(user);
                await _dbcontext.SaveChangesAsync();
                return; 
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
                return;
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
