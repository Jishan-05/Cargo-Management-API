using CargoManagementSystem.DTOs;
using CargoManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// public class ApiClient
// {
//     private readonly HttpClient _client;

//     public ApiClient(string jwtToken)
//     {
//         _client = new HttpClient();
//         _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
//     }

//     public async Task<HttpResponseMessage> GetFeedbackAsync(int feedbackId)
//     {
//         return await _client.GetAsync($"http://localhost:5157/api/Feedback/{feedbackId}/");
//     }

//     // Similarly, you can add other methods for POST, PUT, DELETE, etc.
// }


namespace CargoManagementSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public FeedbackController(IFeedbackService feedbackService,IHttpContextAccessor httpContextAccessor)
        {
            _feedbackService = feedbackService;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetFeedback(int id)
        {
            var feedback = await _feedbackService.GetFeedbackByIdAsync(id);
            if (feedback == null) return NotFound();

            return Ok(feedback);
        }

[Authorize] 
[HttpPost]
public async Task<IActionResult> AddFeedback([FromBody] CreateFeedbackDto feedbackDto)
{
    // Retrieve the customer ID from the JWT claims
    var customerIdClaim = User.FindFirst("CustomerId");
    if (customerIdClaim == null)
    {
        return Unauthorized("Customer ID not found in token.");
    }

    int customerId;
    if (!int.TryParse(customerIdClaim.Value, out customerId))
    {
        return BadRequest("Invalid Customer ID.");
    }

    await _feedbackService.AddFeedbackAsync(customerId, feedbackDto);
    return Ok("Feedback added successfully.");
}

   
    }
}

