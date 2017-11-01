namespace JudgeSystem.App.Data.Models
{
    public class Submission
    {
        public int Id { get; set; }

        public string ExecutableCode { get; set; }

        public int ContestId { get; set; }

        public Contest Contest { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool Compiled { get; set; }
    }
}