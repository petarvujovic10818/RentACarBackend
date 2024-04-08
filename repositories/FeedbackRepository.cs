using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rentacar.data;
using rentacar.interfaces;
using rentacar.models;

namespace rentacar.repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDBContext _context;
        public FeedbackRepository(ApplicationDBContext context)
        {   
            _context = context;
        }
        public async Task<Feedback> createFeedback(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public Task<Feedback?> deleteFeedback(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Feedback?> getFeedbackById(int id)
        {
            return await _context.Feedbacks.Include(c => c.car).FirstOrDefaultAsync(x => x.id == id);

        }

        public async Task<List<Feedback>> getFeedbacksForUser(int userId)
        {
            return await _context.Feedbacks.Include(c => c.car).Where(x => x.userId == userId).ToListAsync();
        }

        public async Task<List<Feedback>> getFeedbacksForCar(int carId)
        {
            return await _context.Feedbacks.Where(x => x.carId == carId).ToListAsync();
        }

        public Task<Feedback?> updateFeedback(int id)
        {
            throw new NotImplementedException();
        }
    }
}