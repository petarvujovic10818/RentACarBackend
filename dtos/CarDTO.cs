using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class CarDTO
    {
        public string marka { get; set; } = string.Empty;

        public string karoserija { get; set; } = string.Empty;

        public string model {get; set; } = string.Empty;

        public string gorivo { get; set; } = string.Empty;
        
        public int zapreminaMotora { get; set; } = 0;

        public int jacinaMotora { get; set; } = 0;

        public decimal cijena { get; set; }

        public List<FeedbackNoCarDTO> feedbacks {get; set;}
    }
}