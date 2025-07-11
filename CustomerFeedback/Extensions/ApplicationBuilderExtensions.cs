using Infrastructure.CustomerFeedback.DataAccess.SeedData;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace CustomerFeedback.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseProjectConfiguration(this IApplicationBuilder app, IHostEnvironment env)
        {
            // Seed data
            SeedDataHelper.Seed(app.ApplicationServices);

            // Swagger
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseCors("AllowedHostsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
} 