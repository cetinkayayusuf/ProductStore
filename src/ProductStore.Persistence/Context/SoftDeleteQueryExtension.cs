using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using ProductStore.Domain.Common;

namespace ProductStore.Persistence.Context;
public static class SoftDeleteQueryExtension
{
    public static void AddSoftDeleteQueryFilter(
        this IMutableEntityType entityData)
    {
        var methodToCall = typeof(SoftDeleteQueryExtension)
            .GetMethod(nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static)
            .MakeGenericMethod(entityData.ClrType);
        var filter = methodToCall.Invoke(null, new object[] { });
        entityData.SetQueryFilter((LambdaExpression)filter);
        entityData.AddIndex(entityData.
             FindProperty(nameof(ISoftDelete.Deleted)));
    }

    private static LambdaExpression GetSoftDeleteFilter<TEntity>()
        where TEntity : class, ISoftDelete
    {
        Expression<Func<TEntity, bool>> filter = x => !x.Deleted;
        return filter;
    }
}
