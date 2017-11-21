using CameraBazaar.Common.Validation.Attributes;
using CameraBazaar.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazaar.Data.Models
{
    public class Camera
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public Make Make { get; set; }

        [Required]
        [ValidCameraModel(ErrorMessage = "Only uppercase letters, digit and - are accepted.")]
        public string Model { get; set; }

        [Required]
        [Price(ErrorMessage = "Price is required and must be a positive number.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Quantity must be in range 0 - 100.")]
        public int? Quantity { get; set; }

        [Required]
        [Range(0, 30, ErrorMessage = "MinShutterSpeed must be in range 0 - 30.")]
        public int? MinShutterSpeed { get; set; }

        [Required]
        [Range(2000, 8000, ErrorMessage = "MaxShutterSPeed must be in range 2000 - 8000.")]
        public int? MaxShutterSPeed { get; set; }

        [Required]
        [Range(50, 100, ErrorMessage = "MinISO must be in range 50 - 100.")]
        public int? MinISO { get; set; }

        [Required]
        [Range(200, 409600, ErrorMessage = "MaxISO must be in range 200 - 409600.")]
        public int? MaxISO { get; set; }

        [Required]
        public bool IsFullFrame { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        [Required]
        [Display(Name = "Light Metering")]
        public int LightMetering { get; set; }

        [Required]
        [Description(ErrorMessage = "The description must be no more than 6000 symbols")]
        public string Description { get; set; }

        [Required]
        [Image(ErrorMessage = "A valid image url must start with http:// or https://")]
        public string ImageUrl { get; set; }
    }
}