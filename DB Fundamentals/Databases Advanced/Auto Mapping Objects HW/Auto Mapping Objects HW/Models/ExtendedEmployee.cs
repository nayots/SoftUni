using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Mapping_Objects_HW.Models
{
    public class ExtendedEmployee
    {
        public ExtendedEmployee()
        {
            this.Subordinates = new List<ExtendedEmployee>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public bool IsOnHoliday { get; set; }

        public ExtendedEmployee Manager { get; set; }

        public ICollection<ExtendedEmployee> Subordinates { get; set; }
    }
}
