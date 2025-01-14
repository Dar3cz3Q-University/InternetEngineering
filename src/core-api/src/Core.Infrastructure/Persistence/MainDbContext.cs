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
        public MainDbContext(
            DbContextOptions<MainDbContext> options,
            PublishDomainEventsInterceptor publishDomainEventsInterceptor)
            : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);

            base.OnConfiguring(optionsBuilder);
        }
    }
}