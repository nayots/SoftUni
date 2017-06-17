using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_ActionPrint
{
    class ActionPrint
    {
        private static void Main(string[] args)
        {
            Action<string> print = (x) => Console.WriteLine(x);

            Console.ReadLine().Split().ToList().ForEach(w => print(w));
        }
    }
}