using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.models
{
    public class Order
    {
        public int id { get; set; }

        public DateTime createdOn { get; set; } = DateTime.Now;
        public DateTime datumPocetka { get; set; } //dateFrom (rental starts)

        public DateTime datumKraja { get; set; } //dateTo (rental ends)
        [Column(TypeName = "decimal(18,2)")]
        public decimal cijena {get; set;} = 0; //price (days * car's price per day)
        public int bodovi { get; set; } = 0; //loyalty points earned in this order (for discounts)
        public int? userId { get; set; } //user making an order
        public int? carId { get; set; } //car as a product

        public User? user {get; set;} //not needed (would make it circular error)
        public Car? car {get; set;}
    }
}