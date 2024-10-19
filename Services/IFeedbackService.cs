using CargoManagementSystem.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoManagementSystem.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDto>> GetAllFeedbacksAsync();
        Task<FeedbackDto> GetFeedbackByIdAsync(int id);
    }
}
