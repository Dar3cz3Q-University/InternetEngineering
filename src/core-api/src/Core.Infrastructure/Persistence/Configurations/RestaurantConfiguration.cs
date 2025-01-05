using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurants");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .HasConversion(
                    id => id.Value,
                    value => RestaurantId.Create(value))
                .ValueGeneratedNever();

            builder.Property(r => r.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(r => r.Description)
                .HasMaxLength(1000)
                .IsRequired();

            builder.OwnsOne(
                r => r.ContactInfo,
                navigationBuilder =>
                {
                    navigationBuilder.Property(ci => ci.Email)
                        .HasMaxLength(255)
                        .HasColumnName("ContactInfo_Email")
                        .IsRequired();

                    navigationBuilder.Property(ci => ci.PhoneNumber)
                        .HasMaxLength(20)
                        .HasColumnName("ContactInfo_PhoneNumber")
                        .IsRequired();
                });

            builder.OwnsOne(
                r => r.OpeningHours,
                navigationBuilder =>
                {
                    navigationBuilder.Property(oh => oh.OpenTime)
                        .HasColumnName("OpeningHours_OpenTime")
                        .IsRequired();

                    navigationBuilder.Property(oh => oh.CloseTime)
                        .HasColumnName("OpeningHours_CloseTime")
                        .IsRequired();
                });

            builder.Property(r => r.IsOpen)
                .IsRequired();

            builder.Property(r => r.MenuId)
                .HasConversion(
                    id => id!.Value,
                    value => value == Guid.Empty ? null : MenuId.Create(value))
                .IsRequired(false);

            builder.Property(r => r.CreatedDateTime)
                .IsRequired();

            builder.Property(r => r.UpdatedDateTime)
                .IsRequired();

            builder.HasOne(r => r.Location)
                .WithOne()
                .HasForeignKey<Restaurant>("AddressId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}