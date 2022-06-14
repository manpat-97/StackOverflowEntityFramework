using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowEF.Entities.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(q => q.Title).IsRequired().HasMaxLength(150);
            builder.Property(q => q.Content).IsRequired().HasMaxLength(30000);
            builder.Property(q => q.Score).HasDefaultValue(0);
            builder.Property(q => q.CreatedDate).HasDefaultValueSql("getutcdate()");
            builder.Property(q => q.UpdatedDate).ValueGeneratedOnUpdate();

            builder.HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            builder.HasMany(q=>q.Comments)
                .WithOne(c=>c.Question)
                .HasForeignKey(c => c.QuestionId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(q => q.User)
                .WithMany(u=>u.Questions)
                .HasForeignKey(q=>q.UserId);

            builder.HasMany(q => q.Tags)
                .WithMany(t => t.Questions)
                .UsingEntity<QuestionTag>(qtBuilder => {

                    qtBuilder.HasOne(qt => qt.Question)
                    .WithMany()
                    .HasForeignKey(qt => qt.QuestionId);

                    qtBuilder.HasOne(qt => qt.Tag)
                    .WithMany()
                    .HasForeignKey(qt => qt.TagId);

                    qtBuilder.HasKey(qt => new { qt.QuestionId, qt.TagId });

                    qtBuilder.HasData(
                        new QuestionTag { QuestionId = 1, TagId = 3},
                        new QuestionTag { QuestionId = 1, TagId = 2},
                        new QuestionTag { QuestionId = 2, TagId = 1},
                        new QuestionTag { QuestionId = 3, TagId = 2},
                        new QuestionTag { QuestionId = 4, TagId = 4 }
                        );

                    }
                );

            builder.HasData(
                new Question() { Id = 1, Title = "Entity Framework", Content = "How to add indexes by using Fluent API?", UserId = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), Score = -2 },
                new Question() { Id = 2, Title = "Asp .Net Core", Content = "How to configure services in ASP.NET Core?", UserId = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), Score = 3},
                new Question() { Id = 3, Title = "Asp .Net Core MVC", Content = "How to add Rotativa.aspnetcore configuration in Program.cs instead of RotativaConfiguration.Setup(env); that was in Startup.cs in .NET 5 and below?", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Score = -3},
                new Question() { Id = 4, Title = "DateTime vs DateTimeOffset", Content = "What is the difference between a DateTime and a DateTimeOffset and when should one be used?", UserId = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Score = 1}
                ) ;
        }
    }
}
