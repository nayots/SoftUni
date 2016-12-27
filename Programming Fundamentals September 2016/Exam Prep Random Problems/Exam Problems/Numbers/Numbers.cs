using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            decimal avrgNum = (decimal)numbers.Average();

            List<int> topNumbers = numbers.Where(x => x > avrgNum).OrderByDescending(x => x).Take(5).ToList();

            if (topNumbers.Any())
            {
                Console.WriteLine(String.Join(" ", topNumbers)); 
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
