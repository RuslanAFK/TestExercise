using TestExercise.Domain.Models;

namespace TestExercise.Services;

public interface IFinderService
{
    Task<Account?> GetAccountFromSystem(Account account);
    Task<Contact?> GetContactFromSystem(Contact contact);
    Task<List<Incident>> GetAllIncidents();
    Task<List<Account>> GetAllAccounts();
    Task<List<Contact>> GetAllContacts();
}