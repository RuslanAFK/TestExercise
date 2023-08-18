using Domain.Models;

namespace Abstractions.Repositories;

public interface IContactRepository
{
    Task<List<Contact>> GetAll();
    Task<Contact?> GetById(int id);
    Task<Contact?> GetByEmail(string email);
    void Add(Contact contact);
    void Update(Contact contact);
    void Delete(Contact contact);
}