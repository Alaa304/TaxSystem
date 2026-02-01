using AutoMapper;
using Core.Domain.Entities;
using Shared.DTOs;

namespace Infrastructure.Mapping;

public class UnitProfile : Profile
{
    public UnitProfile()
    {
        CreateMap<Unit, UnitResultDto>()
            .ForMember(dest => dest.UsageType,
                opt => opt.MapFrom(src => src.UsageType.ToString()))
            .ForMember(dest => dest.FinishingType,
                opt => opt.MapFrom(src => src.FinishingType.ToString()))
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<UnitCreateDto, Unit>();
        CreateMap<UnitUpdateDto, Unit>();
    }
}
