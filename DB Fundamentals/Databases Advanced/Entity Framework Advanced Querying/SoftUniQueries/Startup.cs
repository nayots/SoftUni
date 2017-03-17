using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SoftUniQueries
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();

            //connection string used is .\SQLEXPRESS you can change it in the App.config if you need to.

            //17.Call a Stored Procedure
            //CallStoredProcedure(context);

            //18.Employees Maximum Salaries
            //MaxSalaryPerDepartment(context);
        }

        private static void MaxSalaryPerDepartment(SoftUniContext context)
        {
            var departments = context.Employees
                .GroupBy(e => e.Department)
                .Select(x => new { DepName = x.Key.Name, MaxSalary = x.Key.Employees.Max(m => m.Salary) })
                .Where(w => w.MaxSalary < 30000 || w.MaxSalary > 70000)
                .ToList();

            foreach (var dep in departments)
            {
                Console.WriteLine($"{dep.DepName} - {dep.MaxSalary:F2}");
            }
        }

        private static void CallStoredProcedure(SoftUniContext context)
        {
            Console.Write("Enter Employee First and Last name separated by space: ");

            string[] inputArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var projects = context.GetProjects(inputArgs[0], inputArgs[1]);

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} - {project.Description.Substring(0,30)}... - {project.StartDate.ToString(CultureInfo.CreateSpecificCulture("en-US"))}");
            }
        }
    }
}
