using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.dtos;
using rentacar.models;

namespace rentacar.mappers
{
    public static class FeedbackMapper
    {
        public static FeedbackDTO toFeedbackDTO(this Feedback feedback){
            return new FeedbackDTO{
                commentContent = feedback.commentContent,
                isLiked = feedback.isLiked,
                isDisliked = feedback.isDisliked,
                rating = feedback.rating,
                car = feedback?.car?.toCarDTO()
            };
        }

        public static FeedbackNoCarDTO toNoCarDTO(this Feedback feedback){
            return new FeedbackNoCarDTO{
                commentContent = feedback.commentContent,
                isLiked = feedback.isLiked,
                isDisliked = feedback.isDisliked,
                rating = feedback.rating
            };
        }

        public static Feedback toFeedbackModel(this CreateFeedbackDTO dto){
            return new Feedback{
                commentContent = dto.commentContent,
                isLiked = dto.isLiked,
                isDisliked = dto.isDisliked,
                rating = dto.rating,
                userId = dto.userId,
                carId = dto.carId
            };
        }
    }
}