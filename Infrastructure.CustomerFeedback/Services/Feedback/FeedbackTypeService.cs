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
    public class FeedbackTypeService : IFeedbackTypeService
    {
        private readonly IFeedbackTypeRepository _repository;

        public FeedbackTypeService(IFeedbackTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<List<FeedbackTypeDto>>> GetAllAsync()
        {
            IEnumerable<FeedbackType> entities = await _repository.GetAllAsync();
            entities.ToDto(out List<FeedbackTypeDto> dtoList);
            return new ServiceResponse<List<FeedbackTypeDto>>(200, MessageResources.Success, dtoList);
        }

        public async Task<ServiceResponse<FeedbackTypeDto>> GetByIdAsync(Guid id)
        {
            FeedbackType entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ServiceResponse<FeedbackTypeDto>(404, MessageResources.FeedbackTypeNotFound, null, false);

            entity.ToDto(out FeedbackTypeDto dto);
            return new ServiceResponse<FeedbackTypeDto>(200, MessageResources.Success, dto);
        }

        public async Task<ServiceResponse<Guid>> CreateAsync(CreateFeedbackTypeDto dto, Guid Created_By)
        {           
            dto.ToEntity(out FeedbackType entity);

            entity.Created_By = Created_By;
            await _repository.AddAsync(entity);

            await _repository.SaveAsync();

            return new ServiceResponse<Guid>(200, MessageResources.FeedbackTypeCreated, entity.Id);
        }

        public async Task<ServiceResponse<bool>> EditAsync(Guid id, CreateFeedbackTypeDto dto, Guid modifiedBy)
        {
            FeedbackType entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ServiceResponse<bool>(404, MessageResources.FeedbackTypeNotFound, false, false);

            entity.NameEn = dto.NameEn;
            entity.NameAr = dto.NameAr;
            entity.DescriptionEn = dto.DescriptionEn;
            entity.DescriptionAr = dto.DescriptionAr;
            entity.StartDate = dto.StartDate;
            entity.EndDate = dto.EndDate;
            entity.Last_Modified_By = modifiedBy;
            entity.Last_Modify_Date = DateTime.UtcNow;

            await _repository.UpdateAsync(entity);

            await _repository.SaveAsync();

            return new ServiceResponse<bool>(200, MessageResources.UpdatedSuccessfully, true);
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(Guid id, Guid deletedBy)
        {
            FeedbackType entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ServiceResponse<bool>(404, MessageResources.FeedbackTypeNotFound, false, false);

            entity.Is_Deleted = true;
            entity.Last_Modified_By = deletedBy;
            entity.Last_Modify_Date = DateTime.UtcNow;

            await _repository.UpdateAsync(entity);

            await _repository.SaveAsync();

            return new ServiceResponse<bool>(200, MessageResources.DeletedSuccessfully, true);
        }
    }
}
