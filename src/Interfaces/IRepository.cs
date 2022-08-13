using System.Linq.Expressions;

namespace EntityExtensions.Interfaces;

public interface IRepository<T> where T : Entity
{
    T? Find(Guid id);
    T? FindOne(Expression<Func<T, bool>> criteria);
    IEnumerable<T> FindAll();
    IEnumerable<T> FindMultiple(Expression<Func<T, bool>> criteria);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    TResult HandleTransaction<TResult>(Func<TResult> transaction);
    void HandleTransaction(Action transaction);
}