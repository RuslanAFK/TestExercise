using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestExercise.Controllers.DTOs;
using TestExercise.Services;

namespace TestExercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : Controller
{
    private readonly IFinderService _finderService;
    private readonly IMapper _mapper;

    public ContactsController(IFinderService finderService, IMapper mapper)
    {
        _finderService = finderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var contacts = await _finderService.GetAllContacts();
        var response = _mapper.Map<List<ContactResponseDto>>(contacts);
        return Ok(response);
    }
}
