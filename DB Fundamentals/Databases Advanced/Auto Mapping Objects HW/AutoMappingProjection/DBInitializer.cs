using AutoMappingProjection.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingProjection
{
    public class DBInitializer : DropCreateDatabaseAlways<AMProjectionContext>
    {
        protected override void Seed(AMProjectionContext context)
        {
            Employee manager1 = new Employee
            {
                FirstName = "Mancho",
                LastName = "Manchov",
                Address = "Sofia",
                Birthday = new DateTime(1989, 11, 11),
                Salary = 1999M
            };

            Employee manager2 = new Employee
            {
                FirstName = "Mincho",
                LastName = "Praznikov",
                Address = "Sofia",
                Birthday = new DateTime(1970, 02, 02),
                Salary = 78968M
            };

            Employee emp1 = new Employee
            {
                FirstName = "Slave",
                LastName = "Slavov",
                Address = "Sofia",
                Birthday = new DateTime(1990, 02, 02),
                Salary = 1000M,
                Manager = manager1
            };

            Employee emp2 = new Employee
            {
                FirstName = "Penko",
                LastName = "Ivanov",
                Address = "Sofia",
                Birthday = new DateTime(1980, 02, 02),
                Salary = 3000M,
                Manager = manager1
            };

            Employee emp3 = new Employee
            {
                FirstName = "Vasko",
                LastName = "Vasilev",
                Address = "Sofia",
                Birthday = new DateTime(1970, 02, 02),
                Salary = 6000M,
                Manager = manager1
            };

            Employee emp4 = new Employee
            {
                FirstName = "Bai",
                LastName = "Ivan",
                Address = "Sofia",
                Birthday = new DateTime(1966, 02, 02),
                Salary = 4000M,
                Manager = manager2
            };

            Employee emp5 = new Employee
            {
                FirstName = "Penka",
                LastName = "Losheva",
                Address = "Sofia",
                Birthday = new DateTime(1976, 02, 02),
                Salary = 2000M,
                Manager = manager2
            };

            context.Employees.Add(manager1);
            context.Employees.Add(manager2);
            context.Employees.Add(emp1);
            context.Employees.Add(emp2);
            context.Employees.Add(emp3);
            context.Employees.Add(emp4);
            context.Employees.Add(emp5);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
