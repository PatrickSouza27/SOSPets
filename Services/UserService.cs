﻿using Microsoft.EntityFrameworkCore;
using SOSPets.Data;
using SOSPets.Domain.Models;
using SOSPets.Services.Interface;
using SOSPets.ViewModel.Session;
using SOSPets.ViewModel.Session.Edit;
using System.Runtime.ConstrainedExecution;

namespace SOSPets.Services
{
    public class UserService : IUserService
    {
        private readonly DataContextDatabase _dbcontext;
        private readonly IMapService _mapService;
        public UserService(DataContextDatabase dbcontext, IMapService mapService)
        {
            _dbcontext = dbcontext;
            _mapService = mapService;
        }
        private async Task<Address> SetInformationAddress(AddressViewModelInput addressInput)
        {

            var address = new Address(addressInput);
            var responseJsonRequest = await _mapService.GetLocation(address.PostalCode);
            address.SetGeoLocation(_mapService.GetLatAndLong(responseJsonRequest));
            return address;

        }

        public async Task AddUserAndAddress(UserViewModelInput user)
        {
            var userbank = new User(user);
            var address = SetInformationAddress(user.Address);
            userbank.SetAddress(await address);
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

                user.Address.SetValues(userEdit);
                _dbcontext.Users.Update(user);
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
