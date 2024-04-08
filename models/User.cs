using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.models
{
    //there is identity user thingy
    public class User
    {
        public int id { get; set; }
        public string ime { get; set; } = string.Empty; //name
        public string prezime { get; set; } = string.Empty; //surname
        public string email { get; set; } = string.Empty;
        public string password {get; set;} = string.Empty;
        public DateTime datumRodjenja { get; set; } //date of birth
        public int bodovi { get; set; } = 0; //loyalty points
        public string tip { get; set; } = string.Empty; //type of user
        public List<Feedback> feedbacks {get; set;} = new List<Feedback>();
        public List<Order> orders {get; set;} = new List<Order>();

    }
}