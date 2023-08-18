using Microsoft.AspNetCore.Mvc;
using TestExercise.Abstractions;

namespace TestExercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : Controller
{
    private readonly IAccountRepository _accountRepository;

    public AccountsController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountRepository.GetAll();
        return Ok(accounts);
    }
}
