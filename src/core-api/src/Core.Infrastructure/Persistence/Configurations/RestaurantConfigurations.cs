using Core.Domain.MenuAggregate.Entities;
using Core.Domain.MenuAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class RestaurantConfigurations : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            ConfigureRestaurantsTable(builder);
            ConfigureRestaurantsSectionsTable(builder);
        }

        private void ConfigureRestaurantsSectionsTable(EntityTypeBuilder<Restaurant> builder)
        {
        }

        private void ConfigureRestaurantsTable(
            EntityTypeBuilder<Restaurant> builder)
        {
            //builder.ToTable("Restaurants");

            //builder.HasKey(r => r.Id);

            //builder.Property(r => r.Id)
            //    .ValueGeneratedNever()
            //    .HasConversion(
            //        id => id.Value,
            //        value => RestaurantId.Create(value));

            //builder.Property(r => r.Name)
            //    .HasMaxLength(100);

            //builder.OwnsOne(r => r.Location);

            //builder.Property(r => r.Description)
            //    .HasMaxLength(100);

            //builder.OwnsOne(r => r.ContactInfo);

            //builder.OwnsOne(r => r.OpeningHours);
        }
    }
}
