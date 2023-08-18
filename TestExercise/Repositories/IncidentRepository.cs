using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;
using TestExercise.Domain.Models;

namespace TestExercise.Repositories;

public class IncidentRepository : IIncidentRepository
{
    private readonly AppDbContext _dbContext;

    public IncidentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    private DbSet<Incident> Items
    {
        get => _dbContext.Incidents;
    }

    public async Task<List<Incident>> GetAll()
    {
        return await Items.Include(i => i.Accounts).ToListAsync();
    }

    public async Task<Incident?> GetByName(string name)
    {
        return await Items.FindAsync(name);
    }
    public void Add(Incident incident)
    {
        _dbContext.Incidents.Add(incident);
    }
    public void Update(Incident incident)
    {
        _dbContext.Incidents.Update(incident);
    }
    public void Remove(Incident incident)
    {
        _dbContext.Incidents.Remove(incident);
    }
}
