using ExpenseManagementSystem.Domain.BaseEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ExpenseManagementSystem.Persistence.Interceptors
{
    public class IAuditableEntityInterceptor : SaveChangesInterceptor
    {

        public override ValueTask<InterceptionResult<Int32>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<Int32> result, CancellationToken cancellationToken = default)
        {

            var context = eventData.Context;
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var entries = context.ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAtUtc = DateTime.UtcNow;
                }
                else
                {
                    entity.UpdatedAtUtc = DateTime.UtcNow;
                }
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}

