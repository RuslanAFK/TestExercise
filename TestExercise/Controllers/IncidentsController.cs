using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestExercise.Abstractions;
using TestExercise.Controllers.DTOs;
using TestExercise.Domain.Models;

namespace TestExercise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : Controller
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IncidentsController(IIncidentRepository incidentRepository, IUnitOfWork unitOfWork, IMapper mapper, IAccountRepository accountRepository, IContactRepository contactRepository)
    {
        _incidentRepository = incidentRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _accountRepository = accountRepository;
        _contactRepository = contactRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var incidents = await _incidentRepository.GetAll();
        return Ok(incidents);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RequestDto dto)
    {
        var accountName = dto.AccountName;
        var foundAccount = await _accountRepository.GetByName(accountName);
        if (foundAccount is null)
        {
            return NotFound();
        }
        var email = dto.Email;
        var foundContact = await _contactRepository.GetByEmail(email);

        if (foundContact is not null)
        {
            _mapper.Map<RequestDto, Contact>(dto, foundContact);
            _contactRepository.Update(foundContact);
        }
        else
        {
            var contact = _mapper.Map<RequestDto, Contact>(dto);
            _contactRepository.Add(contact);
            var incident = new Incident()
            {
                Description = dto.IncidentDescription,
                IncidentName = await GenerateIncidentName()
            };
            incident.Accounts.Add(foundAccount);
            _incidentRepository.Add(incident);
        }

        await _unitOfWork.CompleteAsync();

        return Ok();
    }

    private async Task<string> GenerateIncidentName()
    {
        string guid;
        Incident? foundIncident;
        do
        {
            guid = Guid.NewGuid().ToString();
            foundIncident = await _incidentRepository.GetByName(guid);
        } while (foundIncident != null);

        return guid;
    }

}