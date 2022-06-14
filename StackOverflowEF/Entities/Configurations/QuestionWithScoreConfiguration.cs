using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowEF.Entities.ViewModels;

namespace StackOverflowEF.Entities.Configurations
{
    public class QuestionWithScoreConfiguration : IEntityTypeConfiguration<QuestionWithScore>
    {
        public void Configure(EntityTypeBuilder<QuestionWithScore> builder)
        {
            builder.ToView("View_QuestionsScore");
            builder.HasNoKey();
        }
    }
}
