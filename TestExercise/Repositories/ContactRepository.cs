using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;
using TestExercise.Domain.Models;

namespace TestExercise.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _dbContext;

    public ContactRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private DbSet<Contact> Items
    {
        get => _dbContext.Contacts;
    }

    public async Task<List<Contact>> GetAll()
    {
        return await Items.ToListAsync();
    }

    public async Task<Contact?> GetById(int id)
    {
        return await Items.FindAsync(id);
    }
    public async Task<Contact?> GetByEmail(string email)
    {
        return await Items.SingleOrDefaultAsync(a => a.Email == email);
    }
    public void Add(Contact contact)
    {
        _dbContext.Contacts.Add(contact);
    }
    public void Update(Contact contact)
    {
        _dbContext.Contacts.Update(contact);
    }
    public void Remove(Contact contact)
    {
        _dbContext.Contacts.Remove(contact);
    }
}
