using Core.Domain.CategoryAggregate;
using Core.Domain.CategoryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasConversion(
                    id => id.Value,
                    value => CategoryId.Create(value))
                .ValueGeneratedNever();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.ImageUrl)
            .IsRequired();
        }
    }
}
