using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.models;

namespace rentacar.dtos
{
    public class FeedbackDTO
    {
        public string commentContent { get; set; } = string.Empty;
        public bool isLiked { get; set; } = false;
        public bool isDisliked { get; set; } = false;
        public int rating { get; set; } = 0;

        public UpdateCarDTO? car {get; set;}
    }
}