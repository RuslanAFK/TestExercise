using System.Linq.Expressions;

namespace TestExercise.Abstractions;

public interface IBaseRepository<T>
{
    IQueryable<T> GetAll();
    Task<T?> GetById(object id);
    Task<T?> GetBy(Expression<Func<bool>> expression);
    void Add(T item);
    void Update(T item);
    void Delete(T item);
}
