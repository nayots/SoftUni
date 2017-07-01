using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age, double salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
    }

    public double Salary
    {
        get { return salary; }
        set
        {
            if (value <= 460.0)
            {
                throw new ArgumentException($"Salary cannot be less than 460 leva");
            }

            salary = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Age cannot be zero or negative integer");
            }

            age = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"Last name cannot be less than 3 symbols");
            }

            lastName = value;
        }
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"First name cannot be less than 3 symbols");
            }

            firstName = value;
        }
    }

    public void IncreaseSalary(double bonus)
    {
        double amount = this.salary * (bonus / (double)100);

        if (this.age < 30)
        {
            this.salary += (amount / 2);
        }
        else
        {
            this.salary += amount;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} get {this.salary:F2} leva";
    }
}