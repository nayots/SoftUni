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
    class Startup
    {
        static void Main(string[] args)
        {
            AutoMapperInitializer initializer = new AutoMapperInitializer();
            initializer.Initialize();

            //1.Simple Mapping
            SimpleMapping();
            //2.Advanced Mapping
            AdvancedMapping();
        }

        private static void AdvancedMapping()
        {
            ExtendedEmployee emp1 = new ExtendedEmployee
            {
                FirstName = "Gosho",
                LastName = "Ivanov",
                Address = "Sofia blabla",
                IsOnHoliday = false,
                Birthday = new DateTime(1995, 01, 10),
                Salary = 8000M
            };

            ExtendedEmployee emp2 = new ExtendedEmployee
            {
                FirstName = "Bosho",
                LastName = "Ivanov",
                Address = "Plovdiv blabla",
                IsOnHoliday = false,
                Birthday = new DateTime(1995, 01, 10),
                Salary = 9000M
            };

            ExtendedEmployee emp3 = new ExtendedEmployee
            {
                FirstName = "Pesho",
                LastName = "Ivanov",
                Address = "Sofia blabla",
                IsOnHoliday = false,
                Birthday = new DateTime(1995, 01, 10),
                Salary = 7770M
            };

            ExtendedEmployee emp4 = new ExtendedEmployee
            {
                FirstName = "Penko",
                LastName = "Ivanov",
                Address = "Ruse blabla",
                IsOnHoliday = false,
                Birthday = new DateTime(1995, 01, 10),
                Salary = 1000M
            };

            ExtendedEmployee emp5 = new ExtendedEmployee
            {
                FirstName = "Vankata",
                LastName = "Ivanov",
                Address = "Varna blabla",
                IsOnHoliday = false,
                Birthday = new DateTime(1995, 01, 10),
                Salary = 4000M
            };

            ExtendedEmployee emp6 = new ExtendedEmployee
            {
                FirstName = "Milko",
                LastName = "Ivanov",
                Address = "Petrich blabla",
                IsOnHoliday = false,
                Birthday = new DateTime(1995, 01, 10),
                Salary = 500M
            };

            emp1.Manager = emp6;
            emp1.Subordinates.Add(emp2);
            emp1.Subordinates.Add(emp3);
            emp1.Subordinates.Add(emp4);
            emp1.Subordinates.Add(emp5);

            emp2.Manager = emp5;
            emp2.Subordinates.Add(emp3);
            emp2.Subordinates.Add(emp4);

            emp3.Manager = emp4;
            emp3.Subordinates.Add(emp2);
            emp3.Subordinates.Add(emp1);

            emp6.Manager = emp4;
            emp6.Subordinates.Add(emp1);
            emp6.Subordinates.Add(emp2);
            emp6.Subordinates.Add(emp3);
            emp6.Subordinates.Add(emp5);


            List<ExtendedEmployee> employees = new List<ExtendedEmployee>();

            employees.Add(emp1);
            employees.Add(emp2);
            employees.Add(emp3);
            employees.Add(emp4);
            employees.Add(emp5);
            employees.Add(emp6);


            List<ManagerDTO> managerDTos = Mapper.Map<ExtendedEmployee[], List<ManagerDTO>>(employees.ToArray());

            foreach (var mDto in managerDTos)
            {
                Console.WriteLine($"{mDto.FistName} {mDto.LastName} | Employees: {mDto.SubordinatesCount}");
                foreach (var emp in mDto.SubordinatesDTOs)
                {
                    Console.WriteLine($"   - {emp.FirstName} {emp.LastName} {emp.Salary:F2}");
                }
            }
        }

        private static void SimpleMapping()
        {
            Employee employee = new Employee
            {
                FirstName = "Gosho",
                LastName = "Goshov",
                Birthday = new DateTime(1995, 01, 10),
                Address = "Sofia Town blabla",
                Salary = 6000M
            };

            EmployeeDTO dto = Mapper.Map<EmployeeDTO>(employee);

            Console.WriteLine($"{dto.FirstName} {dto.LastName} : {dto.Salary}");
        }
    }
}
