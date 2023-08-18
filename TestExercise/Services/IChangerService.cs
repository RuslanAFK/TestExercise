using TestExercise.Domain.Models;

namespace TestExercise.Services;

public interface IChangerService
{
    Task UpdateContactAsync(Contact contact, Account account);
    Task CreateContactAndIncidentAsync(Contact contact, Incident incident, Account account);
}