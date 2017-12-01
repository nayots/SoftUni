using BookShop.Common.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Web.Models.Books
{
    public class CreateBookModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Price(ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }

        public int Copies { get; set; }

        [Required]
        public string Edition { get; set; }

        public int AgeRestriction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int AuthorId { get; set; }

        public IEnumerable<string> Categories { get; set; }
    }
}