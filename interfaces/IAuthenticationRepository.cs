using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.dtos;

namespace rentacar.interfaces
{
    public interface IAuthenticationRepository
    {
        Task<UserJwtDTO> login(LoginDTO loginDTO); //LOGIN DTO
    }
}