using AutoMapper;
using Core.Domain.Entities;
using Shared.DTOs.Role;

namespace Core.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<CreateRoleDto, Role>();

            CreateMap<Role, RoleResponseDto>()
                .ForMember(dest => dest.RoleID,
                    opt => opt.MapFrom(src => src.Id));
        }
    }
}
