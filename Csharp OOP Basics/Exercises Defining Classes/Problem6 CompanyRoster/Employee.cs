using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Employee
{
    public Employee(string name, decimal salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public Employee(string name, decimal salary, string position, string department, string email, int age) : this(name, salary, position, department)
    {
        this.Email = email;
        this.Age = age;
    }

    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
}