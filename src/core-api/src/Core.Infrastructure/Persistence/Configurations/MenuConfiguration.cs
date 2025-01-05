using Core.Domain.MenuAggregate;
using Core.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        // TODO: Max length to variable
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value))
                .ValueGeneratedNever();

            builder.Property(m => m.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(m => m.Description)
                .HasMaxLength(50)
                .IsRequired();

            builder.OwnsMany(
                m => m.Sections,
                sectionBuilder =>
                {
                    sectionBuilder.ToTable("MenuSections");

                    sectionBuilder.WithOwner().HasForeignKey("MenuId");

                    sectionBuilder.HasKey(s => s.Id);
                    sectionBuilder.Property(s => s.Id)
                        .HasConversion(
                            id => id.Value,
                            value => MenuSectionId.Create(value))
                        .ValueGeneratedNever();

                    sectionBuilder.Property(s => s.Name)
                        .HasMaxLength(50)
                        .IsRequired();

                    sectionBuilder.Property(s => s.Description)
                        .HasMaxLength(50)
                        .IsRequired();

                    sectionBuilder.OwnsMany(
                        s => s.Items,
                        itemBuilder =>
                        {
                            itemBuilder.ToTable("MenuItems");

                            itemBuilder.WithOwner().HasForeignKey("SectionId");

                            itemBuilder.HasKey(i => i.Id);
                            itemBuilder.Property(i => i.Id)
                                .HasConversion(
                                    id => id.Value,
                                    value => MenuItemId.Create(value))
                                .ValueGeneratedNever();

                            itemBuilder.Property(i => i.Name)
                                .HasMaxLength(50)
                                .IsRequired();

                            itemBuilder.Property(i => i.Description)
                                .HasMaxLength(50)
                                .IsRequired();

                            itemBuilder.OwnsOne(
                                i => i.Price,
                                navigationBuilder =>
                                {
                                    navigationBuilder.Property(p => p.Amount)
                                        .HasColumnName("Price_Amount")
                                        .IsRequired();

                                    navigationBuilder.Property(p => p.Currency)
                                        .HasColumnName("Price_Currency")
                                        .IsRequired();
                                });

                            itemBuilder.Property(i => i.IsAvailable)
                                .IsRequired();
                        });

                    sectionBuilder.Property(s => s.CreatedDateTime)
                        .IsRequired();

                    sectionBuilder.Property(s => s.UpdatedDateTime)
                        .IsRequired();
                });

            builder.Property(m => m.CreatedDateTime)
                .IsRequired();

            builder.Property(m => m.UpdatedDateTime)
                .IsRequired();
        }
    }
}