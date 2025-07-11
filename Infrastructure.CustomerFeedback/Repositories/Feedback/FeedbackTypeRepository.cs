using Application.CustomerFeedback.Interfaces.Repositories;
using Domain.CustomerFeedback.Entities;
using Infrastructure.CustomerFeedback.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerFeedback.Repositories
{
    public class FeedbackTypeRepository : IFeedbackTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedbackType>> GetAllAsync()
        {
            return await _context.FeedbackTypes.ToListAsync();
        }

        public async Task<FeedbackType?> GetByIdAsync(Guid id)
        {
            return await _context.FeedbackTypes.FindAsync(id);
        }

        public async Task AddAsync(FeedbackType entity)
        {
            await _context.FeedbackTypes.AddAsync(entity);
        }

        public async Task UpdateAsync(FeedbackType entity)
        {
            _context.FeedbackTypes.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}
