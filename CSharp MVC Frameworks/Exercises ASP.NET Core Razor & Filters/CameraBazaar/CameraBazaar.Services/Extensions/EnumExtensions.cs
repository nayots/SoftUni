using CameraBazaar.Data.Models.Enums;
using System.Collections.Generic;

namespace CameraBazaar.Services.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<LightMetering> GetMeterings(this int metering)
        {
            if (metering == 0)
            {
                return new List<LightMetering>();
            }
            else if (metering == 1)
            {
                return new List<LightMetering>() { LightMetering.Spot };
            }
            else if (metering == 2)
            {
                return new List<LightMetering>() { LightMetering.CenterWeighted };
            }
            else if (metering == 3)
            {
                return new List<LightMetering>() { LightMetering.Spot, LightMetering.CenterWeighted };
            }
            else if (metering == 4)
            {
                return new List<LightMetering>() { LightMetering.Evaluative };
            }
            else if (metering == 5)
            {
                return new List<LightMetering>() { LightMetering.Spot, LightMetering.Evaluative };
            }
            else if (metering == 6)
            {
                return new List<LightMetering>() { LightMetering.CenterWeighted, LightMetering.Evaluative };
            }
            else if (metering == 7)
            {
                return new List<LightMetering>() { LightMetering.Spot, LightMetering.CenterWeighted, LightMetering.Evaluative };
            }

            return null;
        }
    }
}