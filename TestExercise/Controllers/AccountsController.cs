using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestExercise.Controllers.DTOs;
using TestExercise.Services;

namespace TestExercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : Controller
{
    private readonly IFinderService _finderService;
    private readonly IMapper _mapper;

    public AccountsController(IFinderService finderService, IMapper mapper)
    {
        _finderService = finderService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAccounts()
    {
        var accounts = await _finderService.GetAllAccounts();
        var response = _mapper.Map<List<AccountResponseDto>>(accounts);
        return Ok(response);
    }
}
