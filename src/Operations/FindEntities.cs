using System.Linq.Expressions;
using EntityExtensions.Configurations;
using EntityExtensions.Interfaces;

namespace EntityExtensions.Operations;

public static class FindEntitiesByCriteria
{
    public static List<T> Load<T>(this List<T> entities, Expression<Func<T, bool>>? criteria = null, int numberOfElements = 0, int page = 0)  where T : Entity
    {
        var repository = DependencyContainer.Resolve<IRepository<T>>();
        var cacheRepository = DependencyContainer.Resolve<ICacheRepository<T>>();

        var query = criteria == null ? repository?.FindAll() : repository?.FindMultiple(criteria);

        if (page > 0)
            query = query!.Skip(page * page);
        if (numberOfElements > 0)
            query = query!.Take(numberOfElements);

        var result = query!.ToList();
        foreach (var entity in result) cacheRepository?.SaveInCache(entity);
        
        return result;
    }
}