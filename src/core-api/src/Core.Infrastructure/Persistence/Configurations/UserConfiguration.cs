using Core.Domain.UserAggregate;
using Core.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        // TODO: Max length to variable
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value))
                .ValueGeneratedNever();

            builder.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Role)
                .HasConversion(
                    role => role.ToString(),
                    value => Enum.Parse<UserRole>(value))
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.CreatedDateTime)
                .IsRequired();

            builder.Property(u => u.UpdatedDateTime)
                .IsRequired();

            builder.HasMany(u => u.Addresses)
                .WithOne()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}