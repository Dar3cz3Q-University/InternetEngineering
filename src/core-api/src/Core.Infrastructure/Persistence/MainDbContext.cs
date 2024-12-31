using Core.Domain.Common.Models;
using Core.Domain.RestaurantAggregate;
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

        public DbSet<Restaurant> Restaurants { get; set; } = null!;

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