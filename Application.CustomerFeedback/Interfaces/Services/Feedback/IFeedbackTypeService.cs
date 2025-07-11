using Application.CustomerFeedback.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Interfaces.Services
{
    public interface IFeedbackTypeService
    {
        Task<ServiceResponse<List<FeedbackTypeDto>>> GetAllAsync();
        Task<ServiceResponse<FeedbackTypeDto>> GetByIdAsync(Guid id);
        Task<ServiceResponse<Guid>> CreateAsync(CreateFeedbackTypeDto dto, Guid Created_By);
        Task<ServiceResponse<bool>> EditAsync(Guid id, CreateFeedbackTypeDto dto, Guid modifiedBy);
        Task<ServiceResponse<bool>> DeleteAsync(Guid id, Guid deletedBy);
    }
}
