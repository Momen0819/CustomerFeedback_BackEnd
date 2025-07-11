using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Application.CustomerFeedback.DTOs
{
    public class LoginRequestDto
    {
        [Required(ErrorMessageResourceType = typeof(Shared.Resources.MessageResources), ErrorMessageResourceName = "UsernameRequired")]
        public string Username { get; set; }
        [Required(ErrorMessageResourceType = typeof(Shared.Resources.MessageResources), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }
    }
}
