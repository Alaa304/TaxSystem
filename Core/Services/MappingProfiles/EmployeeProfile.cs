using AutoMapper;
using Core.Domain.Entities;
using Shared.DTOs.Employee;

namespace Core.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // =======================
            // CreateEmployeeDto → Employee
            // =======================
            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id يتولد تلقائي
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

            // =======================
            // UpdateEmployeeDto → Employee
            // =======================
            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id مش عايزين نغيره
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            // =======================
            // Employee → EmployeeResponseDto
            // =======================
            CreateMap<Employee, EmployeeResponseDto>()
                .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.Id));        }
    }
}
