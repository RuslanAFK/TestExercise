using System.Linq.Expressions;

namespace Abstractions.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetBy(Expression<Func<T, bool>> expression);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}
