using JudgeSystem.App.Infrastructure.Validation;
using JudgeSystem.App.Infrastructure.Validation.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Models.Contests
{
    public class CreateContestModel
    {
        [Required]
        [ContestTitleAttribute]
        public string ContestName { get; set; }
    }
}