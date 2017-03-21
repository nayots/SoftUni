using AutoMapper;
using AutoMappingProjection.DTOs;
using AutoMappingProjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingProjection
{
    public class AutoMapperInitializer
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                .ForMember(dto => dto.FirstName,
                                opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dto => dto.LastName,
                                opt => opt.MapFrom(src => src.LastName))
                .ForMember(dto => dto.Salary,
                                opt => opt.MapFrom(src => src.Salary))
                .ForMember(dto => dto.ManagerLastName,
                                opt => opt.MapFrom(src => src.Manager.LastName));
            });
        }
    }
}
