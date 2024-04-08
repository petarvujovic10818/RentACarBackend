using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class CreateOrderDTO
    {
        public DateTime createdOn { get; set; } = DateTime.Now;
        [Required]
        public DateTime datumPocetka { get; set; }
        [Required]
        public DateTime datumKraja { get; set; }
        [Range(1,100)]
        public int bodovi { get; set; } = 0;
        [Required]
        [Range(1,1000)]
        public decimal cijena {get; set;} = 0;
        [Required]
        public int userId { get; set; }
        [Required]
        public int carId { get; set; }
    }
}