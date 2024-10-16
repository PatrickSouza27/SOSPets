﻿using SOSPets.Domain.Models;
using SOSPets.ViewModel.Session;
using SOSPets.ViewModel.Session.Edit;

namespace SOSPets.Services.Interface
{
    public interface IUserService
    {
        Task AddUserAndAddress(UserViewModelInput user);
        Task UpdateUser(string uid, EditUserViewModel userEdit);
        Task UpdateAddress(string uid, AddressViewModelInput userEdit);
        Task<User?> GetUserByUID(string uid);
        Task<Address?> GetAddressByUID(string uid);
        Task DeleteUserAndAddress(string uid);
    }
}
