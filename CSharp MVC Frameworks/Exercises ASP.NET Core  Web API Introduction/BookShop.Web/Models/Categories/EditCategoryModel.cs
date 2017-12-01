using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Web.Models.Categories
{
    public class EditCategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}