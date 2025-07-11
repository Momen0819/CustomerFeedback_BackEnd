using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomerFeedback.Entities
{
    public class SimpleBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Deleted { get; set; }
    }

    public class FullBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool Is_Active { get; set; }
        public bool Is_Deleted { get; set; }
        public Guid Created_By { get; set; }
        public DateTime Create_Date { get; set; }
        public Nullable<Guid> Last_Modified_By { get; set; }
        public Nullable<DateTime> Last_Modify_Date { get; set; }
    }
}
