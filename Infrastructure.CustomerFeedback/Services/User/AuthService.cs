using Application.CustomerFeedback.DTOs;
using Application.CustomerFeedback.Interfaces.Services;
using Domain.CustomerFeedback.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.CustomerFeedback.Services.User
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<LoginResponseDto>> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);

            if (user == null || !user.Is_Active || user.Is_Deleted)
            {
                return new ServiceResponse<LoginResponseDto>(
                    (int)HttpStatusCodeEnum.Unauthorized,
                    Shared.Resources.MessageResources.InvalidCredentials,
                    null,
                    false
                );
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
            {
                return new ServiceResponse<LoginResponseDto>(
                    (int)HttpStatusCodeEnum.Unauthorized,
                    Shared.Resources.MessageResources.InvalidCredentials,
                    null,
                    false
                );
            }

            var token = GenerateJwtToken(user);

            return new ServiceResponse<LoginResponseDto>(
                (int)HttpStatusCodeEnum.OK,
                Shared.Resources.MessageResources.LoginSuccessful,
                new LoginResponseDto
                {
                    Token = token,
                    Username = user.UserName
                },
                true
            );
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
