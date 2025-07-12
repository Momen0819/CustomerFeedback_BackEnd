using Application.CustomerFeedback.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Interfaces.Services
{
    public interface IFeedbackService
    {
        Task<ServiceResponse<List<FeedbackDto>>> GetByFeedbackTypeId(Guid Id);
        Task<ServiceResponse<Guid>> CreateAsync(CreateFeedbackDto dto);
        Task<ServiceResponse<List<FeedbackStatisticsDto>>> GetStatistics();
    }
}
