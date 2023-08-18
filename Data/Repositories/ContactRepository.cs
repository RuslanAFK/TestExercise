using Abstractions.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

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
