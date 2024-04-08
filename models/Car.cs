using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.models
{
    public class Car
    {
        public int id { get; set; }
        [MaxLength(20)]
        public string marka { get; set; } = string.Empty; //audi
        public string model { get; set; } = string.Empty; //a3

        public string karoserija { get; set; } = string.Empty; //hatchback

        public string gorivo { get; set; } = string.Empty; //diesel

        public int zapreminaMotora { get; set; } = 0; //1600 (cm3)

        public int jacinaMotora { get; set; } = 0; //116 (HS)

        [Column(TypeName = "decimal(18,2)")]
        public decimal cijena { get; set; } //10.10 euro (per day)

        public List<Feedback> feedbacks { get; set; } = new List<Feedback>();
        public List<Order> orders {get; set;} = new List<Order>(); //not needed
    }
}