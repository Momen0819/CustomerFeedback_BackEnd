using Infrastructure.CustomerFeedback.DataAccess.Contexts;
using Infrastructure.CustomerFeedback.Services;
using Infrastructure.CustomerFeedback.Services.User;
using Infrastructure.CustomerFeedback.Repositories;
using Application.CustomerFeedback.Interfaces.Services;
using Application.CustomerFeedback.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Domain.CustomerFeedback.Entities;

namespace CustomerFeedback.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Localization
            services.AddLocalization(options => options.ResourcesPath = "Shared/Resources");

            var supportedCultures = new[] { "en-us", "ar-sa" };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-us");
                options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
                options.SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
            });

            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            // Identity
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // DI for repositories
            services.AddScoped<IFeedbackTypeRepository, FeedbackTypeRepository>();

            // DI for services 
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFeedbackTypeService, FeedbackTypeService>();

            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowedHostsPolicy", policy =>
                {
                    var allowedHosts = configuration.GetSection("AllowedHosts").Get<string[]>();
                    policy.WithOrigins(allowedHosts)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            // MVC and Swagger
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
} 