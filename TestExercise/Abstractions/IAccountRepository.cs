using TestExercise.Domain.Models;

namespace TestExercise.Abstractions;

public interface IAccountRepository
{
    Task<List<Account>> GetAll();
    Task<Account?> GetById(int id);
    Task<Account?> GetByName(string name);
    void Add(Account account);
    void Update(Account account);
    void Remove(Account account);
}