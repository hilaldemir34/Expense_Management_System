using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ExpenseManagementSystem.Domain.BaseEntity;

namespace ExpenseManagementSystem.Persistence.Interceptors
{
    namespace ExpenseManagementSystem.Persistence.Interceptors
    {
        public class ISoftDeletableEntityInterceptor : SaveChangesInterceptor
        {
            public override ValueTask<InterceptionResult<Int32>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<Int32> result, CancellationToken cancellationToken = default)
            {
                var context = eventData.Context;
                if (context == null)
                {
                    throw new ArgumentNullException(nameof(context));
                }
                var entries = context.ChangeTracker.Entries()
                    .Where(e => e.Entity is ISoftDeletable && e.State == EntityState.Deleted);
                foreach (var entry in entries)
                {
                    entry.State = EntityState.Modified;
                    ((ISoftDeletable)entry.Entity).DeletedAtUtc = DateTime.UtcNow;
                }
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }
        }
    }
}
