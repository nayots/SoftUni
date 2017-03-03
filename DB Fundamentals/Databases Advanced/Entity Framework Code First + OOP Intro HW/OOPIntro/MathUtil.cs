using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class MathUtil
    {

        public static double Sum(double firstNumber, double secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public static double Subtract(double firstNumber, double secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public static double Multiply(double firstNumber, double secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public static double Divide(double devident, double divisor)
        {
            return devident / divisor;
        }

        public static double Percentage(double totalNumber, double percent)
        {
            return totalNumber * (percent / 100);
        }
    }
}
