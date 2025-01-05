using Core.Domain.Common.Entities;
using Core.Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        // TODO: Max length to variable
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id)
                .HasConversion(
                    id => id.Value,
                    value => AddressId.Create(value))
                .ValueGeneratedNever();

            builder.Property(a => a.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.BuildingNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.ApartmentNumber)
                .HasMaxLength(50);

            builder.Property(a => a.PostalCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(a => a.City)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.State)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Country)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Latitude)
                .IsRequired();

            builder.Property(a => a.Longitude)
                .IsRequired();
        }
    }
}