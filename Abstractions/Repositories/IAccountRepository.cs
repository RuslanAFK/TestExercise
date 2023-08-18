using Domain.Models;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
    Task<List<Account>> GetAll();
    Task<Account?> GetById(int id);
    Task<Account?> GetByName(string name);
    void Add(Account account);
    void Update(Account account);
    void Delete(Account account);
}