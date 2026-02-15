using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.Entities;
using Core.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class FavoriteRestaurantConfiguration : IEntityTypeConfiguration<FavoriteRestaurant>
    {
        public void Configure(EntityTypeBuilder<FavoriteRestaurant> builder)
        {
            builder.ToTable("UserFavoriteRestaurants");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                .HasConversion(
                    id => id.Value,
                    value => FavoriteRestaurantId.Create(value))
                .ValueGeneratedNever();

            builder.Property(f => f.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value))
                .IsRequired();

            builder.Property(f => f.RestaurantId)
                .HasConversion(
                    id => id.Value,
                    value => RestaurantId.Create(value))
                .IsRequired();

            builder.HasIndex(f => new { f.UserId, f.RestaurantId })
                .IsUnique();

            builder.Property(f => f.CreatedDateTime)
                .IsRequired();

            builder.Property(f => f.UpdatedDateTime)
                .IsRequired();
        }
    }
}