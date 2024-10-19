using CargoManagementSystem.DTOs;
using CargoManagementSystem.Models;
using CargoManagementSystem.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetAllFeedbacksAsync();
            var feedbackDtos = new List<FeedbackDto>();

            foreach (var feedback in feedbacks)
            {
                feedbackDtos.Add(new FeedbackDto
                {
                    Id = feedback.Id,
                    CreatedBy = feedback.CreatedBy,
                    FeedbackText = feedback.FeedbackText,
                    CreatedAt = feedback.CreatedAt
                });
            }

            return feedbackDtos;
        }

        public async Task<FeedbackDto> GetFeedbackByIdAsync(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(id);
            if (feedback == null) return null;

            return new FeedbackDto
            {
                Id = feedback.Id,
                CreatedBy = feedback.CreatedBy,
                FeedbackText = feedback.FeedbackText,
                CreatedAt = feedback.CreatedAt
            };
        }

        
    }
}
