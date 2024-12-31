using Core.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

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

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            UpdateTimestamps(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateTimestamps(DbContext? context)
        {
            if (context == null) return;

            var entries = context.ChangeTracker.Entries()
                .Where(e => e.Entity is IHasTimestamps &&
                            (e.State == EntityState.Modified || e.State == EntityState.Added));

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                var updatedProperty = entity.GetType().GetProperty(nameof(IHasTimestamps.UpdatedDateTime),
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (updatedProperty != null && updatedProperty.CanWrite)
                {
                    updatedProperty.SetValue(entity, DateTime.UtcNow);
                }

                if (entry.State == EntityState.Added)
                {
                    var createdProperty = entity.GetType().GetProperty(nameof(IHasTimestamps.CreatedDateTime),
                        BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (createdProperty != null && createdProperty.CanWrite)
                    {
                        createdProperty.SetValue(entity, DateTime.UtcNow);
                    }
                }
            }
        }

    }
}