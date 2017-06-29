using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompanyRoster
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = tokens[0];
            decimal salary = decimal.Parse(tokens[1]);
            string position = tokens[2];
            string department = tokens[3];
            Employee emp = new Employee(name, salary, position, department);
            if (tokens.Length > 4)
            {
                int age;
                if (int.TryParse(tokens[4], out age))
                {
                    emp.Age = age;
                }
                else
                {
                    emp.Email = tokens[4];
                }

                if (tokens.Length > 5)
                {
                    emp.Age = int.Parse(tokens[5]);
                }
            }

            employees.Add(emp);
        }

        var bestDep = employees
            .GroupBy(x => x.Department,
                     x => new
                     {
                         Name = x.Name,
                         Salary = x.Salary,
                         Email = string.IsNullOrEmpty(x.Email) ? "n/a" : x.Email,
                         Age = x.Age != null ? x.Age.Value : -1
                     },
                     (department, emplos) =>
                     new
                     {
                         Department = department,
                         Emps = emplos.OrderByDescending(e => e.Salary).ToList()
                     })
                     .OrderByDescending(x => x.Emps.Average(e => e.Salary))
                     .First();

        Console.WriteLine($"Highest Average Salary: {bestDep.Department}");
        foreach (var e in bestDep.Emps)
        {
            Console.WriteLine($"{e.Name} {e.Salary:F2} {e.Email} {e.Age}");
        }
    }
}