using Microsoft.EntityFrameworkCore;
using TestExercise.Abstractions;
using TestExercise.Data;
using TestExercise.Domain.Models;

namespace TestExercise.Repositories;

public class IncidentRepository : BaseRepository<Incident>, IIncidentRepository
{

    public IncidentRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<List<Incident>> GetAll()
    {
        return await Items.Include(i => i.Accounts).ToListAsync();
    }

    public async Task<Incident?> GetByName(string name)
    {
        return await GetBy(i => i.IncidentName == name);
    }
}
