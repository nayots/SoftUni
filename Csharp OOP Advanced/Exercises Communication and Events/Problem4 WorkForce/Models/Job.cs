using Problem4_WorkForce.Models.Contracts;
using System;

namespace Problem4_WorkForce.Models
{
    public delegate void JobDoneHandler(object sender, JobEventArgs args);

    public class Job
    {
        public event JobDoneHandler JobDone;

        private IEmployee employee;

        public Job(string name, int hoursOfWork, IEmployee employee)
        {
            this.Name = name;
            this.HoursOfWork = hoursOfWork;
            this.employee = employee;
        }

        public string Name { get; private set; }
        public int HoursOfWork { get; set; }

        public void Update()
        {
            this.HoursOfWork -= this.employee.WorkHours;
            if (this.HoursOfWork <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.OnJobDone(new JobEventArgs(this));
            }
        }

        private void OnJobDone(JobEventArgs args)
        {
            this.JobDone?.Invoke(this, args);
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWork}";
        }
    }
}