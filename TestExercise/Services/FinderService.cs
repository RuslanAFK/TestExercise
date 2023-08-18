using Abstractions.Repositories;
using Abstractions.Services;
using Domain.Models;

namespace TestExercise.Services;

public class FinderService : IFinderService
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IContactRepository _contactRepository;


    public FinderService(IIncidentRepository incidentRepository, IAccountRepository accountRepository, IContactRepository contactRepository)
    {
        _incidentRepository = incidentRepository;
        _accountRepository = accountRepository;
        _contactRepository = contactRepository;
    }
    
    public async Task<Account?> GetAccountFromSystem(Account account)
    {
        var name = account.AccountName;
        return await _accountRepository.GetByName(name);
    }
    public async Task<Contact?> GetContactFromSystem(Contact contact)
    {
        var email = contact.Email;
        return await _contactRepository.GetByEmail(email);
    }

    public async Task<List<Incident>> GetAllIncidents()
    {
        return await _incidentRepository.GetAll();
    }
    public async Task<List<Account>> GetAllAccounts()
    {
        return await _accountRepository.GetAll();
    }
    public async Task<List<Contact>> GetAllContacts()
    {
        return await _contactRepository.GetAll();
    }
}
