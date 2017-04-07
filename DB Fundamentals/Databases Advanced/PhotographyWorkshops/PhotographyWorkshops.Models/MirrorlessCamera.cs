using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class MirrorlessCamera : Camera
    {
        public string MaxVideoResolution { get; set; }
        public int MaxFrameRate { get; set; }
    }
}
