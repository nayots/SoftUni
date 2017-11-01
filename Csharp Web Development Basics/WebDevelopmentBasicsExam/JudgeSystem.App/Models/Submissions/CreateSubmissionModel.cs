using JudgeSystem.App.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Models.Submissions
{
    public class CreateSubmissionModel
    {
        public string ExecutableCode { get; set; }

        [Required]
        public int ContestId { get; set; }
    }
}