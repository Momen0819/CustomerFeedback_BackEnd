using Application.CustomerFeedback.DTOs;
using Domain.CustomerFeedback.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Mapping
{
    public static class FeedbackTypeMapping
    {
        public static void ToEntity(this CreateFeedbackTypeDto dto, out FeedbackType feedbackType)
        {
            feedbackType = new FeedbackType
            {
                NameEn = dto.NameEn,
                NameAr = dto.NameAr,
                DescriptionEn = dto.DescriptionEn,
                DescriptionAr = dto.DescriptionAr,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Create_Date = DateTime.UtcNow,
                Is_Active = true,
                Is_Deleted = false
            };
        }

        public static void ToDto(this FeedbackType entity, out FeedbackTypeDto dto)
        {
            dto = new FeedbackTypeDto
            {
                Id = entity.Id,
                Name = Shared.CultureHelper.GetCurrentLanguage() == "ar" ? entity.NameAr : entity.NameEn,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        public static void ToDto(this FeedbackType entity, out FeedbackTypeDetailDto dto)
        {
            dto = new FeedbackTypeDetailDto
            {
                Id = entity.Id,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                DescriptionAr = entity.DescriptionAr,
                DescriptionEn = entity.DescriptionEn,
                NameAr = entity.NameAr,
                NameEn = entity.NameEn
            };
        }
        public static void ToDto(this IEnumerable<FeedbackType> entities, out List<FeedbackTypeDto> dtoList)
        {
            dtoList = new List<FeedbackTypeDto>();
            foreach (var entity in entities)
            {
                entity.ToDto(out FeedbackTypeDto dto);
                dtoList.Add(dto);
            }
        }
    }
}
