using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public enum CameraType
    {
        DSLR,
        Mirrorless
    }

    public class Camera
    {
        [Key]
        public int Id { get; set; }

        public CameraType Type { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public bool IsFullFrame { get; set; }

        [Required]
        [Range(100, int.MaxValue)]
        public int MinIso { get; set; }

        public int MaxIso { get; set; }
    }
}
