using Core.Domain.CategoryAggregate;
using Core.Domain.CategoryAggregate.ValueObjects;
using Core.Domain.Common.Entities;
using Core.Domain.Common.Models;
using Core.Domain.OrderAggregate;
using Core.Domain.RestaurantAggregate;
using Core.Domain.RestaurantAggregate.Entities;
using Core.Domain.UserAggregate;
using Core.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence
{
    public class MainDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        private readonly UpdateTimestampsInterceptor _updateTimestampsInterceptor;
        public MainDbContext(
            DbContextOptions<MainDbContext> options,
            PublishDomainEventsInterceptor publishDomainEventsInterceptor,
            UpdateTimestampsInterceptor updateTimestampsInterceptor)
            : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
            _updateTimestampsInterceptor = updateTimestampsInterceptor;
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .Ignore<CategoryId>()
                .ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            optionsBuilder.AddInterceptors(_updateTimestampsInterceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}