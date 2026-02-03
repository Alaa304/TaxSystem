using AutoMapper;
using Core.Domain.Entities;
using Shared.DTOs.Office;

namespace Core.MappingProfiles
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<CreateOfficeDto, Office>();

            CreateMap<Office, OfficeResponseDto>()
                .ForMember(dest => dest.OfficeID,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
