using Domain.Models;

namespace Abstractions.Repositories;

public interface IIncidentRepository
{
    Task<List<Incident>> GetAll();
    Task<Incident?> GetByName(string name);
    void Add(Incident incident);
    void Update(Incident incident);
    void Delete(Incident incident);
}