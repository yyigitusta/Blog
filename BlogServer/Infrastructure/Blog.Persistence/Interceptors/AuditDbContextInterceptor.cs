using Blog.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Interceptors
{
    public class AuditDbContextInterceptor : SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, BaseEntitiy>> Behaviors = new()
        {
            {
                  EntityState.Added,AddedBehavior
            },
            {
                 EntityState.Modified,ModifiedBehavior
            }
        };

        private static void AddedBehavior(DbContext context, BaseEntitiy baseEntity)
        {
            context.Entry(baseEntity).Property(x => x.UpdatedAt).IsModified=false;
            baseEntity.CreatedAt= DateTime.Now;
        }
        private static void ModifiedBehavior(DbContext context, BaseEntitiy baseEntity)
        {
            context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified = false;
            baseEntity.UpdatedAt = DateTime.Now;
        }
        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            foreach(var entry in eventData.Context.ChangeTracker.Entries())
            {
                if(entry.Entity is not BaseEntitiy baseEntitiy) continue;
                if (entry.State is not EntityState.Modified and not EntityState.Added) continue;

                Behaviors[entry.State](eventData.Context, baseEntitiy);
            }


            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}
