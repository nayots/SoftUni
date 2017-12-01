using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public string Edition { get; set; }

        public int AgeRestriction { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public ICollection<CategoryBook> Categories { get; set; } = new List<CategoryBook>();
    }
}