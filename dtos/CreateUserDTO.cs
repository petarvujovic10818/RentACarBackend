using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class CreateUserDTO
    {
        public string ime { get; set; } = string.Empty;
        public string prezime { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [MaxLength(32, ErrorMessage = "Password cannot be longer than 32 characters.")]
        public string password {get; set;} = string.Empty;
        [Required]
        public DateTime datumRodjenja { get; set; }
        [AllowedValues("ADMIN", "NORMAL")]
        public string tip {get; set;} = string.Empty;
    }
}