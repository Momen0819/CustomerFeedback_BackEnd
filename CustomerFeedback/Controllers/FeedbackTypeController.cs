using API.CustomerFeedback.Constants;
using Application.CustomerFeedback.DTOs;
using Application.CustomerFeedback.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Security.Claims;

namespace API.CustomerFeedback.Controllers
{
    [ApiController]
    [Authorize]
    public class FeedbackTypeController : ControllerBase
    {
        private readonly IFeedbackTypeService _feedbackTypeService;
        private readonly IFeedbackService _feedbackService;

        public FeedbackTypeController(IFeedbackTypeService feedbackTypeService, IFeedbackService feedbackService)
        {
            _feedbackTypeService = feedbackTypeService;
            _feedbackService = feedbackService;
        }

        [HttpGet(ApiRoutes.FeedbackType.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _feedbackTypeService.GetAllAsync();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet(ApiRoutes.FeedbackType.GetById)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _feedbackTypeService.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost(ApiRoutes.FeedbackType.Create)]
        public async Task<IActionResult> Create([FromBody] CreateFeedbackTypeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<Guid>(400, "Validation failed", Guid.Empty, false));

            Guid Created_By = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _feedbackTypeService.CreateAsync(dto, Created_By);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut(ApiRoutes.FeedbackType.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditFeedbackTypeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<Guid>(400, "Validation failed", Guid.Empty, false));

            Guid Modified_By = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _feedbackTypeService.EditAsync(dto, Modified_By);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete(ApiRoutes.FeedbackType.Delete)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<Guid>(400, "Validation failed", Guid.Empty, false));

            Guid Deleted_By = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var result = await _feedbackTypeService.DeleteAsync(id, Deleted_By);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet(ApiRoutes.FeedbackType.GetRatings)]
        public async Task<IActionResult> GetRatings(Guid id)
        {
            var result = await _feedbackService.GetByFeedbackTypeId(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
