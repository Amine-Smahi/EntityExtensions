using System.Linq.Expressions;

namespace EntityExtensions.Interfaces;

public interface ICacheRepository<T> where T : Entity
{
    T? FindFromCacheIfExist(Guid id, Func<T?> operation);
    T? FindFromCacheIfExist(Expression<Func<T, bool>> criteria, Func<T?> operation);
    void SaveInCache(T entity);
    void RemoveFromCache(Guid id);
}