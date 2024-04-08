using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.dtos;
using rentacar.models;

namespace rentacar.interfaces
{
    public interface ItokenService
    {
        string createToken(User user);
    }
}