using AutoMapper;
using Core.Domain.Entities;
using Shared.DTOs.SystemLog;

namespace Core.MappingProfiles
{
    public class SystemLogProfile : Profile
    {
        public SystemLogProfile()
        {
            CreateMap<CreateSystemLogDto, SystemLog>();

            CreateMap<SystemLog, SystemLogResponseDto>()
                .ForMember(dest => dest.LogID,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
