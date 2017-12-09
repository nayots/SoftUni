using System;
using System.ComponentModel.DataAnnotations;

namespace NewsOutlet.Data.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}