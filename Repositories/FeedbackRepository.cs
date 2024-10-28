using CargoManagementSystem.Data;
using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id)
        {
            return await _context.Feedbacks.FindAsync(id);
        }

        public async Task AddFeedbackAsync(int customerId, CreateFeedbackDto feedbackDto)
        {
            // Check if the customer exists
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            // Create the feedback entity
            var feedback = new Feedback
            {
                CreatedBy = customerId,
                FeedbackText = feedbackDto.FeedbackText,
                CreatedAt = DateTime.UtcNow
            };

            // Add the feedback to the context
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

    }
}