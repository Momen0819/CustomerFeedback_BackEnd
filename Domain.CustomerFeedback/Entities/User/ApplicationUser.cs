using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomerFeedback.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool Is_Active { get; set; } = true;
        public bool Is_Deleted { get; set; } = false;
    }
}
