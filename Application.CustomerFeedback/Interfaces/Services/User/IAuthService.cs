using Application.CustomerFeedback.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CustomerFeedback.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<LoginResponseDto>> LoginAsync(LoginRequestDto dto);
    }
}
