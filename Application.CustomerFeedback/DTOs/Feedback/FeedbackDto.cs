using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.DTOs
{
    public class FeedbackDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
