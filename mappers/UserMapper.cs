using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using rentacar.dtos;
using rentacar.helpers;
using rentacar.models;

namespace rentacar.mappers
{
    public static class UserMapper
    {
        public static UserDTO toUserDTO(this User userModel){ //binding this to user class
            return new UserDTO{
                ime = userModel.ime,
                prezime = userModel.prezime,
                email = userModel.email,
                datumRodjenja = userModel.datumRodjenja,
                bodovi = userModel.bodovi,
                orders = userModel.orders.Select(o => o.orderToDTO()).ToList(),
                feedbacks = userModel.feedbacks.Select(f => f.toFeedbackDTO()).ToList(),
                tip = userModel.tip
            };
        }

        public static User toUserFromCreateUserDTO(this CreateUserDTO createUserDTO){
            return new User{
                ime = createUserDTO.ime,
                prezime = createUserDTO.prezime,
                email = createUserDTO.email,
                password = SecretHasher.Hash(createUserDTO.password), //hash it
                datumRodjenja = createUserDTO.datumRodjenja,
                bodovi = 0,
                tip = createUserDTO.tip
            };
        }

    }
}