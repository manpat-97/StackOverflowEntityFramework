using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowEF.Entities.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Name).IsRequired().HasMaxLength(25);
            builder.HasIndex(t => t.Name).IsUnique();

            builder.HasData(
                new Tag() { Id = 1, Name = "Asp" },
                new Tag() { Id = 2, Name = ".Net" },
                new Tag() { Id = 3, Name = "EF" },
                new Tag() { Id = 4, Name = "C#" }
                );
        }
    }
}
