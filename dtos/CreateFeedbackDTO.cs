using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.dtos
{
    public class CreateFeedbackDTO
    {
        [Required]
        [MaxLength(320, ErrorMessage = "Comment cannot be longer than 320 characters!")]
        public string commentContent { get; set; } = string.Empty;
        public bool isLiked { get; set; } = false;
        public bool isDisliked { get; set; } = false;
        [Required]
        [Range(1,5, ErrorMessage = "Ratings should be from 1 to 5")]
        public int rating { get; set; } = 0;
        [Required]
        public int userId { get; set; }
        [Required]
        public int carId {  get; set; }
    }
}