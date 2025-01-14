using Core.Domain.Common.ValueObjects;
using Core.Domain.OrderAggregate;
using Core.Domain.OrderAggregate.ValueObjects;
using Core.Domain.RestaurantAggregate.ValueObjects;
using Core.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        // TODO: Max length to variable
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id)
                .HasConversion(
                    id => id.Value,
                    value => OrderId.Create(value))
                .ValueGeneratedNever();

            builder.Property(o => o.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value))
                .IsRequired();

            builder.Property(o => o.RestaurantId)
                .HasConversion(
                    id => id.Value,
                    value => RestaurantId.Create(value))
                .IsRequired();

            builder.Property(o => o.DeliveryAddressId)
                .HasConversion(
                    id => id.Value,
                    value => AddressId.Create(value))
                .IsRequired();

            builder.Property(o => o.OrderStatus)
                .HasConversion(
                    status => status.ToString(),
                    value => Enum.Parse<OrderStatus>(value))
                .IsRequired();

            builder.OwnsOne(
                o => o.TotalPrice,
                navigationBuilder =>
                {
                    navigationBuilder.Property(tp => tp.Amount)
                        .HasColumnName("TotalPrice_Amount")
                        .IsRequired();

                    navigationBuilder.Property(tp => tp.Currency)
                        .HasColumnName("TotalPrice_Currency")
                        .IsRequired();
                });

            builder.Property(o => o.CourierId)
                .HasConversion(
                    id => id.Value,
                    value => value == Guid.Empty ? null : UserId.Create(value));

            builder.Property(o => o.DeliveryTime)
                .IsRequired(false);

            builder.Property(o => o.CreatedDateTime)
                .IsRequired();

            builder.Property(o => o.UpdatedDateTime)
                .IsRequired();

            builder.OwnsMany(
                o => o.ItemsIds,
                itemBuilder =>
                {
                    itemBuilder.ToTable("OrderItems");
                    itemBuilder.WithOwner().HasForeignKey("OrderId");

                    itemBuilder.Property(i => i.Value)
                        .HasColumnName("MenuItemId")
                        .IsRequired();
                });
        }
    }
}