using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LearningSystem.Data.Models;

namespace LearningSystem.Data.Models
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Course> CoursesTrainer { get; set; } = new List<Course>();

        public ICollection<UserCourse> CoursesLearning { get; set; } = new List<UserCourse>();

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public bool TestProp { get; set; }
    }
}