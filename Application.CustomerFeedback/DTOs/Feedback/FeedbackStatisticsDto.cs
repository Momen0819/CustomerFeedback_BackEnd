using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.DTOs
{
    public class FeedbackStatisticsDto
    {
        public Guid FeedbackTypeId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalFeedbacks { get; set; }
        public double AverageRating { get; set; }
    }
}
