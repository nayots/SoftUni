using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_DecimalToBinary_Converter
{
    class ConverterDemo
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var st = new Stack<int>();

            if (n == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (n > 0)
                {
                    var remainder = n % 2;
                    n = n / 2;
                    st.Push(remainder);
                }
            }

            Console.WriteLine(string.Join("", st));
        }
    }
}
