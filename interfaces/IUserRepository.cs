using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.dtos;
using rentacar.models;

namespace rentacar.interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> getUsersAsync();
        Task<User?> getUserByIdAsync(int id);
        Task<User> createUserAsync(User userModel);
        Task<User?> updateUserAsync(int id, UpdateUserDTO updateUserDTO);
        Task<User?> deleteUserAsync(int id);

        Task<bool> userExists(int id);
    }
}