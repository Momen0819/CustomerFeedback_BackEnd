using CustomerFeedback.Extensions;

namespace CustomerFeedback
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register all services
            builder.Services.AddProjectServices(builder.Configuration);

            var app = builder.Build();

            // Configure the middleware pipeline and seed data
            app.UseProjectConfiguration(app.Environment);
            app.MapControllers();
            app.Run();
        }
    }
}
