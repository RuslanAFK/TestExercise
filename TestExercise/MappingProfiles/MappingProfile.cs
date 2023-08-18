using AutoMapper;
using Domain.DTOs;
using Domain.Models;

namespace TestExercise.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        InstantiateRequestDtos();
        InstantiateResponseDtos();
    }

    private void InstantiateRequestDtos()
    {
        CreateMap<RequestDto, Contact>()
            .ForMember(c => c.Email, o
                => o.MapFrom(r => r.Email))
            .ForMember(c => c.FirstName, o
                => o.MapFrom(r => r.FirstName))
            .ForMember(c => c.SecondName, o
                => o.MapFrom(r => r.LastName));
        CreateMap<RequestDto, Incident>()
            .ForMember(i => i.Description, o
                => o.MapFrom(r => r.IncidentDescription));
        CreateMap<RequestDto, Account>()
            .ForMember(a => a.AccountName, o
                => o.MapFrom(r => r.AccountName));
    }
    private void InstantiateResponseDtos()
    {
        CreateMap<Contact, ContactResponseDto>();
        CreateMap<Incident, IncidentResponseDto>();
        CreateMap<Account, AccountResponseDto>();
    }
}
