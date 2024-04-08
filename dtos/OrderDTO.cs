using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class OrderDTO
    {
        public DateTime createdOn { get; set; } = DateTime.Now;
        public DateTime datumPocetka { get; set; }

        public DateTime datumKraja { get; set; }
        public decimal cijena {get; set;}

        public int bodovi { get; set; } = 0;

        // public UserDTO? user {get; set; } = null;

        public UpdateCarDTO? car {get; set;} = null;
        //podaci od useru
        //podaci o autu
    }
}