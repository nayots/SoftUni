using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class Calculation
    {
        private static double planckConst = 6.62606896e-34;

        private static double piValue = 3.14159;

        public  static double ReducedPlanck()
        {
            var result = (planckConst / (2 * piValue));

            return result;
        }
    }
}
