using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Data.Models
{
    public class UserCourse
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}