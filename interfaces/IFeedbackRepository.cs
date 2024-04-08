using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.models;

namespace rentacar.interfaces
{
    public interface IFeedbackRepository
    {
        Task<List<Feedback>> getFeedbacksForUser(int userId);
        Task<List<Feedback>> getFeedbacksForCar(int carId);
        Task<Feedback?> getFeedbackById(int id);
        Task<Feedback> createFeedback(Feedback feedback);
        Task<Feedback?> updateFeedback(int id); //ADD DTO
        Task<Feedback?> deleteFeedback(int id);
    }
}