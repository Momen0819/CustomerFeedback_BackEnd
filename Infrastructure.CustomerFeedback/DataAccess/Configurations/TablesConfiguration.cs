using Domain.CustomerFeedback.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CustomerFeedback.DataAccess.Configurations
{
    public static class TablesConfiguration
    {
        public static void Configuration(ModelBuilder modelBuilder)
        {
            ConfigureFeedbackType(modelBuilder);
            ConfigureFeedback(modelBuilder);
        }

        private static void ConfigureFeedbackType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeedbackType>(entity =>
            {
                entity.ToTable("FeedbackTypes");

                entity.Property(e => e.NameAr)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.NameEn)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.DescriptionAr)
                      .HasMaxLength(500);

                entity.Property(e => e.DescriptionEn)
                      .HasMaxLength(500);

                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
            });
        }

        private static void ConfigureFeedback(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedbacks");

                entity.Property(e => e.FullName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Comment)
                      .IsRequired();

                entity.Property(e => e.Stars)
                      .IsRequired();

                entity.Property(e => e.CreatedDate)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.HasOne(e => e.FeedbackType)
                      .WithMany(ft => ft.Feedbacks)
                      .HasForeignKey(e => e.FeedbackTypeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
