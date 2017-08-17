using Problem4_WorkForce.Models;
using Problem4_WorkForce.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4_WorkForce
{
    class Startup
    {
        private static void Main(string[] args)
        {
            IList<IEmployee> employees = new List<IEmployee>();
            JobList jobs = new JobList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                IEmployee emp = null;

                switch (tokens[0])
                {
                    case "Job":
                        emp = employees.First(e => e.Name == tokens[3]);
                        Job job = new Job(tokens[1], int.Parse(tokens[2]), emp);
                        job.JobDone += jobs.HandleJobCompletion;
                        jobs.Add(job);
                        break;

                    case "StandartEmployee":
                        emp = new StandartEmployee(tokens[1]);
                        employees.Add(emp);
                        break;

                    case "PartTimeEmployee":
                        emp = new PartTimeEmployee(tokens[1]);
                        employees.Add(emp);
                        break;

                    case "Pass":
                        List<Job> dummyJobs = new List<Job>(jobs);
                        foreach (var j in dummyJobs)
                        {
                            j.Update();
                        }
                        break;

                    case "Status":
                        jobs.ForEach(j => Console.WriteLine(j));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}