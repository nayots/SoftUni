namespace Problem3StudentsAndCourses.Data.Models
{
    public class StudentsCourses
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}