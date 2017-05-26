using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_Periodic_Table
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var compounds = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var ele in compounds)
                {
                    if (!elements.Contains(ele))
                    {
                        elements.Add(ele);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
