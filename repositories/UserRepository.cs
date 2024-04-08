using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rentacar.data;
using rentacar.dtos;
using rentacar.interfaces;
using rentacar.models;

namespace rentacar.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context){
            _context = context;
        }

        public async Task<User> createUserAsync(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> deleteUserAsync(int id)
        {
            var userModel = await _context.Users.FirstOrDefaultAsync(x => x.id == id);

            if(userModel == null) return null;

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> getUserByIdAsync(int id)
        {
            return await _context.Users.Include(f => f.feedbacks).ThenInclude(x => x.car).Include(o => o.orders).ThenInclude(o => o.car)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<User>> getUsersAsync()
        {
            
            return await _context.Users.Include(f => f.feedbacks).ThenInclude(x => x.car)
                .Include(o => o.orders).ThenInclude(o => o.car).ToListAsync();
        }

        public async Task<User?> updateUserAsync(int id, UpdateUserDTO updateUserDTO)
        {
            var existingUser = await _context.Users.Include(f => f.feedbacks).ThenInclude(x => x.car).Include(o => o.orders).ThenInclude(o => o.car)
                .FirstOrDefaultAsync(x => x.id == id);

            if(existingUser == null) return null;

            existingUser.ime = updateUserDTO.ime;
            existingUser.prezime = updateUserDTO.prezime;
            existingUser.email = updateUserDTO.email;
            existingUser.datumRodjenja = updateUserDTO.datumRodjenja;
            existingUser.bodovi = updateUserDTO.bodovi;
            existingUser.tip = updateUserDTO.tip;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> userExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.id == id);
        }
    }
}