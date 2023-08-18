using Domain.Models;

namespace Abstractions.Services;

public interface IChangerService
{
    Task UpdateContactAsync(Contact contact, Account account);
    Task CreateContactAndIncidentAsync(Contact contact, Incident incident, Account account);
}