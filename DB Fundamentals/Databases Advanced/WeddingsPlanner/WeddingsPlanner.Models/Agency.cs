using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.Models
{
    public class Agency
    {
        public Agency()
        {
            this.OrganizedWeddings = new List<Wedding>();
        }
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmployeesCount { get; set; }

        public string Town { get; set; }

        public virtual ICollection<Wedding> OrganizedWeddings { get; set; }
    }
}
