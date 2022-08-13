using System.Linq.Expressions;
using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;

namespace EntityExtensions.Operations;

public static class LoadEntityByCriteria
{
    public static T? Load<T>(this T? entity, Expression<Func<T, bool>> criteria)  where T : Entity
    {
        var cacheRepository = DependencyContainer.Resolve<ICacheRepository<T>>();
        
        entity = cacheRepository?.FindFromCacheIfExist(criteria,() =>
        {
            var repository = DependencyContainer.Resolve<IRepository<T>>();
            return repository?.FindOne(criteria);
        });
        
        if(entity != null) 
            cacheRepository?.SaveInCache(entity!);
        
        return entity;
    }
}