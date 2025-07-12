using Application.CustomerFeedback.DTOs;
using Application.CustomerFeedback.Interfaces.Repositories;
using Application.CustomerFeedback.Interfaces.Services;
using Domain.CustomerFeedback.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.CustomerFeedback.Mapping;
using Shared.Resources;

namespace Infrastructure.CustomerFeedback.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackService(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<Guid>> CreateAsync(CreateFeedbackDto dto)
        {
            if (await _repository.CheckEmailExistsAsync(dto.Email.Trim(),dto.FeedbackTypeId))
            {
                return new ServiceResponse<Guid>(400, MessageResources.EmailAlreadyExists, Guid.Empty, false);
            }

            dto.ToEntity(out Feedback entity);

            await _repository.AddAsync(entity);

            await _repository.SaveAsync();

            return new ServiceResponse<Guid>(200, MessageResources.FeedbackCreated, entity.Id);
        }

        public async Task<ServiceResponse<List<FeedbackDto>>> GetByFeedbackTypeId(Guid Id)
        {
            var entities = await _repository.GetByFeedbackTypeId(Id);
            entities.ToDto(out List<FeedbackDto> dtoList);
            return new ServiceResponse<List<FeedbackDto>>(200, MessageResources.Success, dtoList);
        }

        public async Task<ServiceResponse<List<FeedbackStatisticsDto>>> GetStatistics()
        {
            List<FeedbackStatisticsDto> dtoList = await _repository.GetStatistics();
            return new ServiceResponse<List<FeedbackStatisticsDto>>(200, MessageResources.Success, dtoList);
        }
    }
}
