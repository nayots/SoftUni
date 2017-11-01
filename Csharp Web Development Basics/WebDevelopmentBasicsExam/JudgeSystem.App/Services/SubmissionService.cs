using JudgeSystem.App.Data;
using JudgeSystem.App.Data.Models;
using JudgeSystem.App.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly JudgeSystemDbContext db;

        public SubmissionService(JudgeSystemDbContext db)
        {
            this.db = db;
        }

        public void Create(int creatorId, string executableCode, int contestId, bool compiles)
        {
            var submission = new Submission()
            {
                ContestId = contestId,
                UserId = creatorId,
                ExecutableCode = executableCode,
                Compiled = compiles
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }
    }
}