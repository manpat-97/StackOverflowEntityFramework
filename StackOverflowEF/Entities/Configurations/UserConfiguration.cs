using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StackOverflowEF.Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();
            builder.Property(u => u.Name).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired();

            builder.HasMany(u => u.Answers)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData
                (
                new User() {Id = Guid.Parse("3b16f6ed-85e1-47c7-a466-e32bdb6fafc9"), Email = "user1@example.com", Name = "MarianKowalski123"},
                new User() {Id = Guid.Parse("0b72e7c5-6c7a-42ca-b6c4-687cdc937d98"), Email = "user2@example.com", Name = "UserDrugi2"},
                new User() {Id = Guid.Parse("1b55d748-2ed4-4092-a1cc-a26c430d9d5e"), Email = "user3@example.com", Name = "Batman3"}
                );
        }
    }
}
