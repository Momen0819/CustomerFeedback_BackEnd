using API.CustomerFeedback.Constants;
using Application.CustomerFeedback.DTOs;
using Application.CustomerFeedback.Interfaces.Services;
using Infrastructure.CustomerFeedback.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Resources;
using System.Security.Claims;

namespace API.CustomerFeedback.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class PublicController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IFeedbackTypeService _feedbackTypeService;

        public PublicController(IFeedbackService feedbackService, IFeedbackTypeService feedbackTypeService)
        {
            _feedbackService = feedbackService;
            _feedbackTypeService = feedbackTypeService;
        }

        [HttpGet(ApiRoutes.Public.GetFeedbackType)]
        public async Task<IActionResult> GetFeedbackType(Guid id)
        {
            var result = await _feedbackTypeService.GetByIdAsync(id);

            DateTime now = DateTime.UtcNow;
            if (result.Data.StartDate > now || result.Data.EndDate < now)
                return StatusCode(404,new ServiceResponse<string>(404, MessageResources.FeedbackTypeNotAvaliableThisTime, null, false));

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost(ApiRoutes.Public.CreateFeedback)]
        public async Task<IActionResult> Create([FromBody] CreateFeedbackDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<Guid>(400, "Validation failed", Guid.Empty, false));

            var result = await _feedbackService.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
