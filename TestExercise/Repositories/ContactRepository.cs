using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;
using TestExercise.Domain.Models;

namespace TestExercise.Repositories;

public class ContactRepository : BaseRepository<Contact>, IContactRepository
{

    public ContactRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<List<Contact>> GetAll()
    {
        return await Items.ToListAsync();
    }

    public async Task<Contact?> GetById(int id)
    {
        return await GetBy(c => c.ContactId == id);
    }
    public async Task<Contact?> GetByEmail(string email)
    {
        return await GetBy(a => a.Email == email);
    }
}
