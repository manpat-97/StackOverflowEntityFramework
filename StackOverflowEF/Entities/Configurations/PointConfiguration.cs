using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowEF.Entities.Configurations
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.Property(p => p.Value).HasDefaultValue(0);
            builder.HasCheckConstraint("CK_Points_AnswerId_QuestionId_NotBothNull", "([QuestionId] IS NULL OR [AnswerId] IS NULL) AND NOT ([QuestionId] IS NULL AND [AnswerId] IS NULL)");

            builder.HasOne(p => p.Question)
                .WithMany(q => q.Points)
                .HasForeignKey(q => q.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(p => p.Answer)
             .WithMany(a => a.Points)
             .HasForeignKey(a => a.AnswerId)
             .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(p => p.User)
                .WithMany(u=>u.Points)
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData(
                new Point() { Id = 1, QuestionId = 1, UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), Value = -1},
                new Point() { Id = 2, QuestionId = 2, UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), Value = 1},
                new Point() { Id = 3, QuestionId = 3, UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), Value = -1},
                new Point() { Id = 4, QuestionId = 2, UserId = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), Value = 1},
                new Point() { Id = 5, QuestionId = 3, UserId = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), Value = -1},
                new Point() { Id = 7, QuestionId = 4, UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Value = 1},
                new Point() { Id = 8, QuestionId = 2, UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Value = 1 },
                new Point() { Id = 9, QuestionId = 1, UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Value = -1 },
                new Point() { Id = 10, QuestionId = 3, UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Value = -1 }
                );
        }
    }
}
