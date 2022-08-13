using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;

namespace EntityExtensions.Operations;

public static class UpdateEntity
{
    public static T Update<T>(this T entity) where T : Entity
    {
        var repository = DependencyContainer.Resolve<IRepository<T>>();
        var cacheRepository = DependencyContainer.Resolve<ICacheRepository<T>>();
        
        repository!.Update(entity);
        cacheRepository?.SaveInCache(entity);
        
        return entity;
    }
}