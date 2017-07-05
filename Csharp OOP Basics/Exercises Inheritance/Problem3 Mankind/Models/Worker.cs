using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_Mankind.Models
{
    public class Worker : Human
    {
        private decimal weeklySalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal salary, decimal workingHours) : base(firstName, lastName)
        {
            this.WeeklySalary = salary;
            this.WorkHoursPerDay = workingHours;
        }

        public decimal HourlyWage { get { return CalculateHourlyWage(); } }

        private decimal CalculateHourlyWage()
        {
            return this.WeeklySalary / (5 * this.WorkHoursPerDay);
        }

        public decimal WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal WeeklySalary
        {
            get { return this.weeklySalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }

                this.weeklySalary = value;
            }
        }

        public override string LastName
        {
            get => base.LastName;
            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName");
                }

                base.LastName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {this.FirstName}");
            sb.AppendLine($"Last Name: {this.LastName}");
            sb.AppendLine($"Week Salary: {this.WeeklySalary:F2}");
            sb.AppendLine($"Hours per day: {WorkHoursPerDay:F2}");
            sb.Append($"Salary per hour: {HourlyWage:F2}");

            return sb.ToString();
        }
    }
}