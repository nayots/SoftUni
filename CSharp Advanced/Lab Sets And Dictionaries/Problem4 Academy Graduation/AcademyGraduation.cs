using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_Academy_Graduation
{
    class AcademyGraduation
    {
        static void Main(string[] args)
        {
            var data = new SortedDictionary<string, double[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var scores = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
                data.Add(name, scores);
            }

            foreach (var st in data)
            {
                Console.WriteLine($"{st.Key} is graduated with {st.Value.Average()}");
            }
        }
    }
}
