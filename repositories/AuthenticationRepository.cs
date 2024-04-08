using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using rentacar.data;
using rentacar.dtos;
using rentacar.helpers;
using rentacar.interfaces;

namespace rentacar.repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly ItokenService _tokenService;
        public AuthenticationRepository(ApplicationDBContext context, ItokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public async Task<UserJwtDTO> login(LoginDTO loginDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.email == loginDTO.email);
            if(SecretHasher.Verify(loginDTO.password, user.password)){
                return new UserJwtDTO{
                    JWT = _tokenService.createToken(user)
                };
            }
            return new UserJwtDTO{
                JWT = ""
            };
        }
    }
}