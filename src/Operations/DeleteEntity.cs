using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;

namespace EntityExtensions.Operations;

public static class DeleteEntity
{
    public static void Delete<T>(this T entity) where T : Entity
    {
        var repository = DependencyContainer.Resolve<IRepository<T>>();
        var cacheRepository = DependencyContainer.Resolve<ICacheRepository<T>>();
        
        repository?.Delete(entity);
        cacheRepository?.RemoveFromCache(entity.Id);
    }
}