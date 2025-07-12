using Application.CustomerFeedback.DTOs;
using Domain.CustomerFeedback.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Mapping
{
    public static class FeedbackMapping
    {
        public static void ToDto(this IEnumerable<Feedback> entities, out List<FeedbackDto> dtoList)
        {
            dtoList = new List<FeedbackDto>();
            foreach (var entity in entities)
            {
                entity.ToDto(out FeedbackDto dto);
                dtoList.Add(dto);
            }
        }

        public static void ToDto(this Feedback entity, out FeedbackDto dto)
        {
            dto = new FeedbackDto
            {
                Comment = entity.Comment, 
                CreatedDate = entity.CreatedDate,
                Email = entity.Email,
                FullName = entity.FullName, 
                Stars = entity.Stars
            };
        }

        public static void ToEntity(this CreateFeedbackDto dto, out Feedback feedback)
        {
            feedback = new Feedback
            {
                Stars = dto.Stars,
                Comment = dto.Comment,
                Email = dto.Email.Trim(),
                FullName = dto.FullName.Trim(),
                FeedbackTypeId = dto.FeedbackTypeId,
                CreatedDate = DateTime.UtcNow,
                Is_Active = true,
                Is_Deleted = false
            };
        }
    }
}
