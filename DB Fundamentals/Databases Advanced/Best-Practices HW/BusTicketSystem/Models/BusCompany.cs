using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BusCompany
    {
        public BusCompany()
        {
            this.Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public double Rating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
