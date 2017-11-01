using System.Collections.Generic;

namespace JudgeSystem.App.Data.Models
{
    public class Contest
    {
        public int Id { get; set; }

        public string ContestName { get; set; }

        public string CreatorEmail { get; set; }

        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();

        public ICollection<UserContest> Participants { get; set; } = new List<UserContest>();
    }
}