using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowEF.Entities.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Content).IsRequired().HasMaxLength(600);
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("getutcdate()");
            builder.Property(c => c.UpdatedDate).ValueGeneratedOnUpdate();
            builder.HasCheckConstraint("CK_Comments_AnswerId_QuestionId_NotBothNull", "(([QuestionId] IS NULL OR [AnswerId] IS NULL) AND NOT ([QuestionId] IS NULL AND [AnswerId] IS NULL))");

            builder.HasData(
                new Comment() { Id = 1, Content = "Good", UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), AnswerId = 1 },
                new Comment() { Id = 2, Content = "Wrong", UserId = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), AnswerId = 2 },
                new Comment() { Id = 3, Content = "Nice", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), QuestionId = 2 },
                new Comment() { Id = 4, Content = "Comment 4", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), QuestionId = 2 },
                new Comment() { Id = 5, Content = "Comment", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), QuestionId = 2 }, 
                new Comment() { Id = 6, Content = "Comment 6", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), QuestionId = 2 },
                new Comment() { Id = 7, Content = "Comment 7", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), QuestionId = 1 },
                 new Comment() { Id = 8, Content = "Wrong 2", UserId = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), AnswerId = 2 }
                );
        }
    }
}
