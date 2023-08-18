using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;
using TestExercise.Domain.Models;

namespace TestExercise.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
    public override async Task<List<Account>> GetAll()
    {
        return await Items.Include(a => a.Contacts).ToListAsync();
    }

    public async Task<Account?> GetById(int id)
    {
        return await GetBy(a => a.AccountId == id);
    }
    public async Task<Account?> GetByName(string name)
    {
        return await GetBy(a => a.AccountName == name);
    }
}
