using Auto_Mapping_Objects_HW.DTOs;
using Auto_Mapping_Objects_HW.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Mapping_Objects_HW
{
    public class AutoMapperInitializer
    {
        public void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<ExtendedEmployee, ExtendedEmployeeDTO>();
                cfg.CreateMap<ExtendedEmployee, ManagerDTO>()
                .ForMember(dto => dto.SubordinatesDTOs,
                                    opt => opt.MapFrom(src => src.Subordinates))
                .ForMember(dto => dto.SubordinatesCount,
                                    opt => opt.MapFrom(src => src.Subordinates.Count()))
                .ForMember(dto => dto.FistName,
                                    opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dto => dto.LastName,
                                    opt => opt.MapFrom(src => src.LastName));
            });
        }
    }
}
