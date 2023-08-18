using Abstractions.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

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
