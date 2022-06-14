using Microsoft.EntityFrameworkCore;
using StackOverflowEF.Entities.ViewModels;

namespace StackOverflowEF.Entities
{
    public class StackOverflowContext : DbContext
    {
        public StackOverflowContext(DbContextOptions<StackOverflowContext> options) : base(options)
        {

        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionTag> QuestionTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<QuestionWithScore> ViewQuestionsWithScore { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
