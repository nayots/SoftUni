using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Data.Models
{
    public class UserContest
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ContestId { get; set; }

        public Contest Contest { get; set; }
    }
}