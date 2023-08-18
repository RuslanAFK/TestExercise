using TestExercise.Abstractions;
using TestExercise.Domain.Models;

namespace TestExercise.Services;

public class ChangerService : IChangerService
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;


    public ChangerService(IIncidentRepository incidentRepository, IContactRepository contactRepository, IUnitOfWork unitOfWork)
    {
        _incidentRepository = incidentRepository;
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task UpdateContactAsync(Contact contact, Account account)
    {
        LinkContactWithAccount(contact, account);
        UpdateContact(contact);
        await _unitOfWork.CompleteAsync();
    }
    public async Task CreateContactAndIncidentAsync(Contact contact, Incident incident, Account account)
    {
        LinkContactWithAccount(contact, account);
        LinkAccountWithIncident(account, incident);
        await SetUniqueIncidentName(incident);

        CreateContact(contact);
        CreateIncident(incident);
        await _unitOfWork.CompleteAsync();
    }

    private void LinkContactWithAccount(Contact contact, Account account)
    {
        account.Contacts.Add(contact);
    }
    private void LinkAccountWithIncident(Account account, Incident incident)
    {
        incident.Accounts.Add(account);
    }
    private void CreateContact(Contact contact)
    {
        _contactRepository.Add(contact);
    }
    private void UpdateContact(Contact contact)
    {
        _contactRepository.Update(contact);
    }
    private void CreateIncident(Incident incident)
    {
        _incidentRepository.Add(incident);
    }
    private async Task SetUniqueIncidentName(Incident incident)
    {
        string guid;
        bool causesDuplication;
        do
        {
            guid = Guid.NewGuid().ToString();
            var duplicateItem = await _incidentRepository.GetByName(guid);
            causesDuplication = duplicateItem is not null;
        } while (causesDuplication);

        incident.IncidentName = guid;
    }
}
