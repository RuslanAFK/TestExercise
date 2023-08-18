using TestExercise.Domain.Models;

namespace TestExercise.Abstractions;

public interface IContactRepository
{
    Task<List<Contact>> GetAll();
    Task<Contact?> GetById(int id);
    Task<Contact?> GetByEmail(string email);
    void Add(Contact contact);
    void Update(Contact contact);
    void Remove(Contact contact);
}