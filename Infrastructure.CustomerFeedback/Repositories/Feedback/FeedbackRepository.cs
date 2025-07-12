using Application.CustomerFeedback.DTOs;
using Application.CustomerFeedback.Interfaces.Repositories;
using Dapper;
using Domain.CustomerFeedback.Entities;
using Infrastructure.CustomerFeedback.DataAccess.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerFeedback.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public FeedbackRepository(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<IEnumerable<Feedback>> GetByFeedbackTypeId(Guid Id)
        {
            return await _context.Feedbacks.AsNoTracking().Where(s => s.FeedbackTypeId == Id).ToListAsync();
        }

        public async Task AddAsync(Feedback entity)
        {
            await _context.Feedbacks.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckEmailExistsAsync(string email,Guid FeedbackTypeId)
        {
            return await _context.Feedbacks.AsNoTracking()
                .AnyAsync(f => f.Email == email && f.FeedbackTypeId == FeedbackTypeId);
        }

        public async Task<List<FeedbackStatisticsDto>> GetStatistics()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DBConnection"));

            var result = await connection.QueryAsync<FeedbackStatisticsDto>(
                "sp_GetFeedbackStatistics",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
    }

}
