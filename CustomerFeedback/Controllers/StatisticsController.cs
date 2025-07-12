using API.CustomerFeedback.Constants;
using Application.CustomerFeedback.Interfaces.Services;
using Infrastructure.CustomerFeedback.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.CustomerFeedback.Controllers
{
    [ApiController]
    [Authorize]
    public class StatisticsController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public StatisticsController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet(ApiRoutes.Statistics.Get)]
        public async Task<IActionResult> Get()
        {
            var result = await _feedbackService.GetStatistics();
            return StatusCode(result.StatusCode, result);
        }
    }
}
