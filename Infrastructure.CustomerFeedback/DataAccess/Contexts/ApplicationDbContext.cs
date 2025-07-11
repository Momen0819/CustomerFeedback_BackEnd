using Domain.CustomerFeedback.Entities;
using Infrastructure.CustomerFeedback.DataAccess.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerFeedback.DataAccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            TablesConfiguration.Configuration(modelBuilder);
        }

        public DbSet<FeedbackType> FeedbackTypes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
