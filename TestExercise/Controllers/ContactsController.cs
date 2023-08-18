using Microsoft.AspNetCore.Mvc;
using TestExercise.Abstractions;

namespace TestExercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : Controller
{
    private readonly IContactRepository _contactRepository;

    public ContactsController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _contactRepository.GetAll();
        return Ok(contacts);
    }
}
