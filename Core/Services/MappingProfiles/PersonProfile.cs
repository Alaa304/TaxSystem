using Core.Domain.Entities;
using Shared.DTOs;
using AutoMapper;
namespace Infrastructure.Mapping;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonResultDto>()
            .ForMember(dest => dest.PersonType,
                opt => opt.MapFrom(src => src.PersonType.ToString()));

        CreateMap<PersonCreateDto, Person>();

        CreateMap<PersonUpdateDto, Person>();
    }
}
