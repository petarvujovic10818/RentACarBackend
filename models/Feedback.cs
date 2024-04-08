using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.models
{
    public class Feedback
    {
        public int id { get; set; }
        public string commentContent { get; set; } = string.Empty;
        public bool isLiked { get; set; } = false;
        public bool isDisliked { get; set; } = false;
        public int rating { get; set; } = 0;
        public int? userId { get; set; } //user giving the feedback
        public int? carId {  get; set; }//car receiving the feedback

        public User? user {get; set;}
        public Car? car {get; set;}
     
    }
}