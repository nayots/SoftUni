using System;
using System.ComponentModel.DataAnnotations;

namespace NewsOutlet.Web.Models
{
    public class CreateEditNewsModel
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        public DateTime? PublishDate { get; set; }
    }
}