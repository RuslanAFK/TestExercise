using TestExercise.Abstractions;
using TestExercise.Data;

namespace TestExercise.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompleteAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
