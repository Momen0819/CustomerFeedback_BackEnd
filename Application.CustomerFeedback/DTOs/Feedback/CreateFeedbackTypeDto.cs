using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.DTOs
{
    public class CreateFeedbackTypeDto
    {
        [Required(ErrorMessage = "NameEn is required")]
        [MaxLength(100, ErrorMessage = "NameEn must be at most 100 characters")]
        public string NameEn { get; set; }

        [Required(ErrorMessage = "NameAr is required")]
        [MaxLength(100, ErrorMessage = "NameAr must be at most 100 characters")]
        public string NameAr { get; set; }

        [MaxLength(500, ErrorMessage = "DescriptionEn must be at most 500 characters")]
        public string? DescriptionEn { get; set; }

        [MaxLength(500, ErrorMessage = "DescriptionAr must be at most 500 characters")]
        public string? DescriptionAr { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }
    }
}
