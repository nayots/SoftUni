using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        [Range(1.00,10.00, ErrorMessage ="Grade must be from 1.00 to 10.00")]
        public double Grade { get; set; }

        [ForeignKey("BusCompany")]
        public int BusCompanyId { get; set; }

        public virtual BusCompany BusCompany { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
