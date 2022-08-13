using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;

namespace EntityExtensions.Operations;

public static class FindEntity
{
    public static T? Load<T>(this T? entity, Guid id = new())  where T : Entity
    {
        var entityId= id == Guid.Empty ? entity!.Id : id;
        
        var cacheRepository = DependencyContainer.Resolve<ICacheRepository<T>>();
        entity = cacheRepository?.FindFromCacheIfExist(entityId, () =>
        {
            var repository = DependencyContainer.Resolve<IRepository<T>>();
            return repository?.Find(entityId);
        });
        
        if(entity != null) 
            cacheRepository?.SaveInCache(entity);
        
        return entity;
    }
}