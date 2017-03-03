using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDB.Models
{
    public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }

        public StoreLocation(string locationName)
        {
            this.LocationName = locationName;
            this.SalesInStore = new HashSet<Sale>();
        }

        public StoreLocation(string locationName, HashSet<Sale> sales)
        {
            this.LocationName = locationName;
            this.SalesInStore = sales;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        public virtual HashSet<Sale> SalesInStore { get; set; }
    }
}
