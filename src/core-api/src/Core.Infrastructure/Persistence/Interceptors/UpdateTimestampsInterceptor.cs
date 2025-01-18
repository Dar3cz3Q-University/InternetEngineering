using Core.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Core.Infrastructure.Persistence.Interceptors
{
    public class UpdateTimestampsInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            UpdateTimestamps(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateTimestamps(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void UpdateTimestamps(DbContext? context)
        {
            if (context == null) return;

            var entries = context.ChangeTracker.Entries()
                .Where(e => e.Entity is IHasTimestamps &&
                            (e.State == EntityState.Modified || e.State == EntityState.Added))
                .ToList();

            foreach (var entry in entries)
            {
                UpdateEntityTimestamps(entry);
            }
        }

        private static void UpdateEntityTimestamps(EntityEntry entry)
        {
            if (entry.Entity is IHasTimestamps entity)
            {
                entity.UpdatedDateTime = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDateTime = DateTime.UtcNow;
                }
            }

            foreach (var navigation in entry.Navigations)
            {
                if (navigation.CurrentValue is IEnumerable<object> children)
                {
                    foreach (var child in children)
                    {
                        var childEntry = entry.Context.Entry(child);
                        UpdateEntityTimestamps(childEntry);
                    }
                }
                else if (navigation.CurrentValue is object child)
                {
                    var childEntry = entry.Context.Entry(child);
                    UpdateEntityTimestamps(childEntry);
                }
            }
        }
    }
}