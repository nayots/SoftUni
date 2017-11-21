using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazaar.Data.Models.Enums
{
    public enum LightMetering
    {
        Spot = 1,

        [Display(Name = "Center Weighted")]
        CenterWeighted = 2,

        Evaluative = 4
    }
}