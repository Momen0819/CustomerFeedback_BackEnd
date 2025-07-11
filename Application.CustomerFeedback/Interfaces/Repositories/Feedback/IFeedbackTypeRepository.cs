using Domain.CustomerFeedback.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Interfaces.Repositories
{
    public interface IFeedbackTypeRepository
    {
        Task<IEnumerable<FeedbackType>> GetAllAsync();
        Task<FeedbackType?> GetByIdAsync(Guid id);
        Task AddAsync(FeedbackType entity);
        Task UpdateAsync(FeedbackType entity);
        Task SaveAsync();
    }
}
