using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;
using TestExercise.Domain.Models;

namespace TestExercise.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _dbContext;

    public AccountRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private DbSet<Account> Items
    {
        get => _dbContext.Set<Account>();
    }

    public async Task<List<Account>> GetAll()
    {
        return await Items.Include(a => a.Contacts).ToListAsync();
    }

    public async Task<Account?> GetById(int id)
    {
        return await Items.FindAsync(id);
    }
    public async Task<Account?> GetByName(string name)
    {
        return await Items.SingleOrDefaultAsync(a => a.AccountName == name);
    }
    public void Add(Account account)
    {
        _dbContext.Accounts.Add(account);
    }
    public void Update(Account account)
    {
        _dbContext.Accounts.Update(account);
    }
    public void Remove(Account account)
    {
        _dbContext.Accounts.Remove(account);
    }
}
