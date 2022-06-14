using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowEF.Entities.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.Property(a => a.Content).IsRequired().HasMaxLength(2000);
            builder.Property(a => a.CreatedDate).HasDefaultValueSql("getutcdate()");
            builder.Property(a => a.UpdatedDate).ValueGeneratedOnUpdate();
            builder.Property(a => a.Score).HasDefaultValue(0);

            builder.HasMany(a => a.Comments)
                .WithOne(c => c.Answer)
                .HasForeignKey(c => c.AnswerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData
                (
                new Answer() { Id = 1, Content = "You can do it in dbContext class", QuestionId = 1, UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9") },
                new Answer() { Id = 2, Content = "You need to configure in Program.cs", QuestionId = 2, UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9") },
                new Answer() { Id = 3, Content = "You can just configure like this:", QuestionId = 3, UserId = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98") },
                new Answer() { Id = 4, Content = "DateTimeOffset is a representation of instantaneous time.", QuestionId = 4, UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e") }
                );
        }
    }
}
