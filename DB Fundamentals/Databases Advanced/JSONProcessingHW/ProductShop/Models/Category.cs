using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
