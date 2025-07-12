using Domain.CustomerFeedback.Entities;
using Infrastructure.CustomerFeedback.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerFeedback.DataAccess.SeedData
{
    public static class SeedDataHelper
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            ApplicationUser admin = userManager.FindByNameAsync("admin").Result;

            if (admin == null)
            {
                ApplicationUser newAdmin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    Is_Active = true,
                    Is_Deleted = false
                };

                userManager.CreateAsync(newAdmin, "Admin@123").Wait();
            }
        }
    }
}
