using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMappingProjection.DTOs;
using AutoMappingProjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingProjection
{
    class Startup
    {
        static void Main(string[] args)
        {
            AutoMapperInitializer amInitializer = new AutoMapperInitializer();
            amInitializer.Initialize();

            //3.Projection
            Projection();
        }

        private static void Projection()
        {
            using (var context = new AMProjectionContext())
            {
                List<EmployeeDto> employees = context
                    .Employees
                    .Where( d => d.Birthday.Year < 1990)
                    .ProjectTo<EmployeeDto>()
                    .OrderByDescending(o => o.Salary)
                    .ToList();

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Salary:F2} - Manager: {emp.ManagerLastName ?? "[no manager]"}");
                }
            }
        }
    }
}
