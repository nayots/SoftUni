using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;


namespace SoftUniDB
{
    class SoftUniDB
    {
        static void Main(string[] args)
        {
            //GetAllEmployeesData();
            //GetEmployeesWithSalaryOver50k();
            //GetEmployeesFromRaD();
            //NewAddressAndUpdate();
            //FindEmployeesInPeriod();
            //AddressesByTownName();
            //EmployeeWIthId147();
            //DepWithMoreThan5Emp();
            //FindLatest10Projects();
            //IncreaseSalaries();
            //EmpWithSAInFName();
            //DeleteProjectById();
            //RemoveTowns();
        }

        private static void RemoveTowns()
        {
            Console.Write("Enter town name: ");
            string townName = Console.ReadLine();

            using (var context = new SoftUniContext())
            {
                var affectedEmployees = context.Employees.Where(x => x.Address.Town.Name == townName);

                foreach (var e in affectedEmployees)
                {
                    e.AddressID = null;
                }
                var addresses = affectedEmployees.Select(x => x.Address);
                context.Addresses.RemoveRange(addresses);

                if (addresses.Count() > 0)
                {
                    var town = addresses.Select(x => x.Town).First();
                    context.Towns.Remove(town);
                }
                int deletedAddresses = addresses.Count();
                context.SaveChanges();

                if (deletedAddresses == 1)
                {
                    Console.WriteLine($"{deletedAddresses} address in {townName} was deleted");
                }
                else
                {
                    Console.WriteLine($"{deletedAddresses} addresses in {townName} were deleted");
                }
            }
        }

        private static void DeleteProjectById()
        {
            using (var context = new SoftUniContext())
            {
                var project = context.Projects.Where(x => x.ProjectID == 2).First();

                var employees = project.Employees;

                foreach (var e in employees)
                {
                    e.Projects.Remove(project);
                }

                context.Projects.Remove(project);
                context.SaveChanges();

                var projectsList = context.Projects.Take(10).Select(x => x.Name);

                foreach (var p in projectsList)
                {
                    Console.WriteLine(p);
                }
            }
        }

        private static void EmpWithSAInFName()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees.Where(x => x.FirstName.Substring(0, 2).ToUpper() == "SA");

                foreach (var e in employees)
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F4})");
                }
            }
        }

        private static void IncreaseSalaries()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(x => x.Department.Name == "Engineering"
                           || x.Department.Name == "Tool Design"
                           || x.Department.Name == "Marketing"
                           || x.Department.Name == "Information Services");

                foreach (var e in employees)
                {
                    e.Salary *= 1.12M;
                }
                context.SaveChanges();

                foreach (var em in employees)
                {
                    Console.WriteLine($"{em.FirstName} {em.LastName} (${em.Salary:F6})");
                }
            }
        }

        private static void FindLatest10Projects()
        {
            using (var context = new SoftUniContext())
            {
                var projects = context.Projects
                    .OrderByDescending(x => x.StartDate)
                    .Take(10)
                    .OrderBy(a => a.Name);
                string dateFormat = "M/d/yyyy h:mm:ss tt";
                foreach (Project proj in projects)
                {
                    string EndDate = string.Empty;
                    if (proj.EndDate.HasValue)
                    {
                        EndDate = proj.EndDate.Value.ToString(dateFormat, CultureInfo.InvariantCulture);
                    }
                    Console.WriteLine($"{proj.Name} {proj.Description} {proj.StartDate.ToString(dateFormat, CultureInfo.InvariantCulture)} {EndDate}");
                }
            }
        }

        private static void DepWithMoreThan5Emp()
        {
            using (var context = new SoftUniContext())
            {
                var departments = context.Departments
                    .Where(x => x.Employees.Count > 5)
                    .OrderBy(x => x.Employees.Count);

                foreach (var d in departments)
                {
                    Console.WriteLine($"{d.Name} {d.Employee.FirstName}");
                    foreach (var e in d.Employees)
                    {
                        Console.WriteLine($"{e.FirstName} {e.LastName} {e.JobTitle}");
                    }
                }
            }
        }

        private static void EmployeeWIthId147()
        {
            using (var context = new SoftUniContext())
            {
                Employee emp147 = context.Employees.Where(i => i.EmployeeID == 147).First();

                Console.WriteLine($"{emp147.FirstName} {emp147.LastName} {emp147.JobTitle}");
                foreach (Project p in emp147.Projects.OrderBy(x => x.Name))
                {
                    Console.WriteLine(p.Name);
                }
            }
        }

        private static void AddressesByTownName()
        {
            using (var context = new SoftUniContext())
            {
                var addresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(t => t.Town.Name)
                    .Take(10)
                    .ToList();

                foreach (var adrs in addresses)
                {
                    Console.WriteLine($"{adrs.AddressText}, {adrs.Town.Name} - {adrs.Employees.Count} employees");
                }
            }
        }

        private static void FindEmployeesInPeriod()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(x => x.Projects
                                          .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003).Any())
                                          .Take(30)
                                          .ToList();
                string dateFormat = @"M/d/yyyy h:mm:ss tt";
                foreach (Employee emp in employees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Manager.FirstName}");
                    foreach (Project p in emp.Projects)
                    {
                        string EndDate = string.Empty;
                        if (p.EndDate.HasValue)
                        {
                            EndDate = p.EndDate.Value.ToString(dateFormat, CultureInfo.InvariantCulture);
                        }
                        Console.WriteLine($"--{p.Name} {p.StartDate.ToString(dateFormat, CultureInfo.InvariantCulture)} {EndDate}");
                    }
                }
            }
        }

        private static void NewAddressAndUpdate()
        {
            using (var context = new SoftUniContext())
            {
                Address newAddress = new Address() { AddressText = "Vitoshka 15", TownID = 4 };

                var nakov = context.Employees.Where(x => x.LastName == "Nakov").First();

                nakov.Address = newAddress;
                context.SaveChanges();

                var employees = context.Employees.OrderByDescending(x => x.AddressID).Take(10).Select(a => a.Address.AddressText).ToList();

                Console.WriteLine(string.Join("\n", employees));
            }
        }

        private static void GetEmployeesFromRaD()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees
                    .Where(d => d.Department.Name == "Research and Development")
                    .OrderBy(x => x.Salary)
                    .ThenByDescending(y => y.FirstName)
                    .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
                }
            }
        }

        private static void GetEmployeesWithSalaryOver50k()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees.Where(e => e.Salary > 50000).ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName}");
                }
            }
        }

        private static void GetAllEmployeesData()
        {
            using (var context = new SoftUniContext())
            {
                var employees = context.Employees.ToList().OrderBy(x => x.EmployeeID);

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary}");
                }
            }
        }
    }
}
