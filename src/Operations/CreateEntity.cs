using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;

namespace EntityExtensions.Operations;

public static class CreateEntity
{
    public static T Create<T>(this T entity) where T : Entity
    {
        var repository = DependencyContainer.Resolve<IRepository<T>>();
        var cacheRepository = DependencyContainer.Resolve<ICacheRepository<T>>();

        repository?.Create(entity);
        cacheRepository?.SaveInCache(entity);
        
        return entity;
    }
}