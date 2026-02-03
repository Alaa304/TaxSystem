using AutoMapper;
using Core.Domain.Entities;
using Shared.Dtos.ArchiveDTOs;

namespace Core.MappingProfiles
{
    public class ArchiveProfile : Profile
    {
        public ArchiveProfile()
        {
            CreateMap<CreateArchiveDto, Archive>();

            CreateMap<Archive, ArchiveResponseDto>()
                .ForMember(dest => dest.ArchivedID,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
