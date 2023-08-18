using Abstractions.Services;
using AutoMapper;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestExercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IFinderService _finderService;
    private readonly IChangerService _changerService;

    public IncidentsController(IMapper mapper, IFinderService finderService, IChangerService changerService)
    {
        _mapper = mapper;
        _finderService = finderService;
        _changerService = changerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllIncidents()
    {
        var incidents = await _finderService.GetAllIncidents();
        var response = _mapper.Map<List<IncidentResponseDto>>(incidents);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateIncident(RequestDto dto)
    {
        var account = _mapper.Map<RequestDto, Account>(dto);
        account = await _finderService.GetAccountFromSystem(account);
        if (account is null)
        {
            return NotFound();
        }
        var inputContact = _mapper.Map<RequestDto, Contact>(dto);
        var foundContact = await _finderService.GetContactFromSystem(inputContact);
        if (foundContact is null)
        {
            var incident = _mapper.Map<RequestDto, Incident>(dto);
            await _changerService.CreateContactAndIncidentAsync(inputContact, incident, account);
        }
        else
        {
            _mapper.Map(dto, foundContact);
            await _changerService.UpdateContactAsync(foundContact, account);
        }

        return Ok();
    }
}