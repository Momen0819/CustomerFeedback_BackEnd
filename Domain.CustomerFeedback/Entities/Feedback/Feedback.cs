using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomerFeedback.Entities
{
    public class Feedback : SimpleBaseEntity
    {
        public Guid FeedbackTypeId { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public FeedbackType FeedbackType { get; set; }
    }
}
