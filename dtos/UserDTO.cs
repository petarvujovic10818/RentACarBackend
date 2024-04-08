using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.models;

namespace rentacar.dtos
{
    public class UserDTO
    {
        public string ime { get; set; } = string.Empty;
        public string prezime { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public DateTime datumRodjenja { get; set; }
        public int bodovi { get; set; } = 0;
        public string tip { get; set; } = string.Empty;

        public List<OrderDTO> orders {get; set;}
        public List<FeedbackDTO> feedbacks {get; set;}
    }
}