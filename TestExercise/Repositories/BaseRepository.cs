using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;

namespace TestExercise.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;

    protected BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private DbSet<T> Table => _dbContext.Set<T>();
    protected IQueryable<T> Items => Table;
    public abstract Task<List<T>> GetAll();
    public virtual async Task<T?> GetBy(Expression<Func<T, bool>> expression)
    {
        return await Table.SingleOrDefaultAsync(expression);
    }

    public virtual void Add(T item)
    {
        Table.Add(item);
    }
    public virtual void Update(T item)
    {
        Table.Update(item);
    }
    public virtual void Delete(T item)
    {
        Table.Remove(item);
    }
}
