using EntityFrameworkCore.Triggered;
using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Common;
using ProductStore.Persistence.Context;

public class SoftDeleteTrigger : IBeforeSaveTrigger<ISoftDelete>
{
    readonly ApplicationDbContext _dbContext;
    public SoftDeleteTrigger(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task BeforeSave(ITriggerContext<ISoftDelete> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType == ChangeType.Deleted)
        {
            var entry = _dbContext.Entry(context.Entity);
            context.Entity.Deleted = true;
            entry.State = EntityState.Modified;
        }

        await Task.CompletedTask;
    }
}