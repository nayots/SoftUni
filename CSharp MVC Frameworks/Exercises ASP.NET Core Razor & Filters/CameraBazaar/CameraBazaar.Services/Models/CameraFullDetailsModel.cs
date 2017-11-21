using CameraBazaar.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CameraBazaar.Services.Models
{
    public class CameraFullDetailsModel
    {
        public Make Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public bool InStock { get; set; }

        public string SellerId { get; set; }

        public string SellerUsername { get; set; }

        public string ImgUrl { get; set; }

        [Display(Name = "Is Full Frame:")]
        public bool IsFullFrame { get; set; }

        [Display(Name = "Min Shutter Speed:")]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Max Shutter Speed:")]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Min ISO:")]
        public int MinISO { get; set; }

        [Display(Name = "Max ISO:")]
        public int MaxISO { get; set; }

        [Display(Name = "Video Resolution:")]
        public string VideoResolution { get; set; }

        [Display(Name = "Light Metering")]
        public IEnumerable<LightMetering> LightMetering { get; set; } = new List<LightMetering>();

        public string Description { get; set; }
    }
}