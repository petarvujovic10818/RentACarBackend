using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class UpdateUserDTO
    {
        public string ime { get; set; } = string.Empty;
        public string prezime { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public DateTime datumRodjenja { get; set; }
        public int bodovi {get; set;}
        public string tip {get; set;} = string.Empty;
    }
}