using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class LoginDTO
    {
        [Required]
        public string email {get; set;} = String.Empty;
        [Required]
        public string password {get; set;} = String.Empty;
    }
}