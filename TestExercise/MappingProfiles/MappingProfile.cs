using AutoMapper;
using TestExercise.Controllers.DTOs;
using TestExercise.Domain.Models;

namespace TestExercise.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RequestDto, Contact>()
            .ForMember(c => c.Email, o
                => o.MapFrom(r => r.Email))
            .ForMember(c => c.FirstName, o
                => o.MapFrom(r => r.FirstName))
            .ForMember(c => c.SecondName, o
                => o.MapFrom(r => r.LastName));
    }
}
