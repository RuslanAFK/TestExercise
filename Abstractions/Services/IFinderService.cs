using Domain.Models;

namespace Abstractions.Services;

public interface IFinderService
{
    Task<Account?> GetAccountFromSystem(Account account);
    Task<Contact?> GetContactFromSystem(Contact contact);
    Task<List<Incident>> GetAllIncidents();
    Task<List<Account>> GetAllAccounts();
    Task<List<Contact>> GetAllContacts();
}