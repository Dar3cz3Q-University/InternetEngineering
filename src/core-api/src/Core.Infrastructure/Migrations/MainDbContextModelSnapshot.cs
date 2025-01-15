﻿// <auto-generated />
using System;
using Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Core.Infrastructure.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Common.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ApartmentNumber")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("BuildingNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Core.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CourierId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeliveryAddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeliveryTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Core.Domain.RestaurantAggregate.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("MenuId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MenuId")
                        .IsUnique();

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Core.Domain.RestaurantAggregate.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Restaurants", (string)null);
                });

            modelBuilder.Entity("Core.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Common.Entities.Address", b =>
                {
                    b.HasOne("Core.Domain.UserAggregate.User", null)
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Core.Domain.OrderAggregate.Order", b =>
                {
                    b.OwnsOne("Core.Domain.Common.ValueObjects.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("TotalPrice_Amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("TotalPrice_Currency");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsMany("Core.Domain.RestaurantAggregate.ValueObjects.MenuItemId", "ItemsIds", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("Value")
                                .HasColumnType("uuid")
                                .HasColumnName("MenuItemId");

                            b1.HasKey("OrderId", "Id");

                            b1.ToTable("OrderItems", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("ItemsIds");

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.RestaurantAggregate.Entities.Menu", b =>
                {
                    b.HasOne("Core.Domain.RestaurantAggregate.Restaurant", null)
                        .WithOne("Menu")
                        .HasForeignKey("Core.Domain.RestaurantAggregate.Entities.Menu", "MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsMany("Core.Domain.RestaurantAggregate.Entities.MenuSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("CreatedDateTime")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<DateTime>("UpdatedDateTime")
                                .HasColumnType("timestamp with time zone");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("Core.Domain.RestaurantAggregate.Entities.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid");

                                    b2.Property<DateTime>("CreatedDateTime")
                                        .HasColumnType("timestamp with time zone");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)");

                                    b2.Property<bool>("IsAvailable")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)");

                                    b2.Property<Guid?>("SectionId")
                                        .HasColumnType("uuid");

                                    b2.Property<DateTime>("UpdatedDateTime")
                                        .HasColumnType("timestamp with time zone");

                                    b2.HasKey("Id");

                                    b2.HasIndex("SectionId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("SectionId");

                                    b2.OwnsOne("Core.Domain.Common.ValueObjects.Money", "Price", b3 =>
                                        {
                                            b3.Property<Guid>("MenuItemId")
                                                .HasColumnType("uuid");

                                            b3.Property<decimal>("Amount")
                                                .HasColumnType("numeric")
                                                .HasColumnName("Price_Amount");

                                            b3.Property<string>("Currency")
                                                .IsRequired()
                                                .HasColumnType("text")
                                                .HasColumnName("Price_Currency");

                                            b3.HasKey("MenuItemId");

                                            b3.ToTable("MenuItems");

                                            b3.WithOwner()
                                                .HasForeignKey("MenuItemId");
                                        });

                                    b2.Navigation("Price")
                                        .IsRequired();
                                });

                            b1.Navigation("Items");
                        });

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Core.Domain.RestaurantAggregate.Restaurant", b =>
                {
                    b.HasOne("Core.Domain.Common.Entities.Address", "Location")
                        .WithOne()
                        .HasForeignKey("Core.Domain.RestaurantAggregate.Restaurant", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Core.Domain.RestaurantAggregate.ValueObjects.ContactInfo", "ContactInfo", b1 =>
                        {
                            b1.Property<Guid>("RestaurantId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("character varying(255)")
                                .HasColumnName("ContactInfo_Email");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)")
                                .HasColumnName("ContactInfo_PhoneNumber");

                            b1.HasKey("RestaurantId");

                            b1.ToTable("Restaurants");

                            b1.WithOwner()
                                .HasForeignKey("RestaurantId");
                        });

                    b.OwnsOne("Core.Domain.RestaurantAggregate.ValueObjects.OpeningHours", "OpeningHours", b1 =>
                        {
                            b1.Property<Guid>("RestaurantId")
                                .HasColumnType("uuid");

                            b1.Property<TimeOnly>("CloseTime")
                                .HasColumnType("time without time zone")
                                .HasColumnName("OpeningHours_CloseTime");

                            b1.Property<TimeOnly>("OpenTime")
                                .HasColumnType("time without time zone")
                                .HasColumnName("OpeningHours_OpenTime");

                            b1.HasKey("RestaurantId");

                            b1.ToTable("Restaurants");

                            b1.WithOwner()
                                .HasForeignKey("RestaurantId");
                        });

                    b.Navigation("ContactInfo")
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("OpeningHours")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.RestaurantAggregate.Restaurant", b =>
                {
                    b.Navigation("Menu")
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Domain.UserAggregate.User", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
