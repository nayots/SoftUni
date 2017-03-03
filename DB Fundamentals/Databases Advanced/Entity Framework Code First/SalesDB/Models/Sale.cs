using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB.Models
{
    public class Sale
    {
        public Sale()
        {

        }

        public Sale(Product product, Customer customer, StoreLocation location, DateTime date)
        {
            this.Product = product;
            this.Customer = customer;
            this.StoreLocation = location;
            this.Date = date;
        }

        [Key]
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual StoreLocation StoreLocation { get; set; }

        public DateTime Date { get; set; }
    }
}
