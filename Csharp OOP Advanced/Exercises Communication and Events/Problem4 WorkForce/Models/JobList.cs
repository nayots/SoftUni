using System.Collections.Generic;

namespace Problem4_WorkForce.Models
{
    public class JobList : List<Job>
    {
        public void HandleJobCompletion(object sender, JobEventArgs args)
        {
            this.Remove(args.Job);
        }
    }
}