using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem23EmployeesRelations.Data.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}