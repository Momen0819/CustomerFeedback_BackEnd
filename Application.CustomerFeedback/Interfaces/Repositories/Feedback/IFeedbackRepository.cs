using Application.CustomerFeedback.DTOs;
using Domain.CustomerFeedback.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Interfaces.Repositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetByFeedbackTypeId(Guid Id);
        Task<bool> CheckEmailExistsAsync(string email,Guid FeedbackTypeId);
        Task<List<FeedbackStatisticsDto>> GetStatistics();
        Task AddAsync(Feedback entity);
        Task SaveAsync();
    }
}
