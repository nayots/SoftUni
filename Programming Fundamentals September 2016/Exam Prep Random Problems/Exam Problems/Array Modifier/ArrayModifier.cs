using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayModifier
{
    class ArrayModifier
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] comArgs = command.Split();

                int firstIndex = 0;
                int secIndex = 0;

                switch (comArgs[0])
                {
                    case "swap":

                        firstIndex = int.Parse(comArgs[1]);
                        secIndex = int.Parse(comArgs[2]);

                        numbers = Swap(numbers, firstIndex, secIndex);
                        break;
                    case "multiply":

                        firstIndex = int.Parse(comArgs[1]);
                        secIndex = int.Parse(comArgs[2]);

                        numbers = Multiply(numbers, firstIndex, secIndex);
                        break;
                    case "decrease":
                        numbers = Decrease(numbers);
                        break;
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ",numbers));
        }

        private static long[] Decrease(long[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] -= 1;
            }

            return numbers;
        }

        private static long[] Multiply(long[] numbers, int firstIndex, int secIndex)
        {
            numbers[firstIndex] *= numbers[secIndex];

            return numbers;
        }

        private static long[] Swap(long[] numbers, int firstIndex, int secIndex)
        {
            long tempData = numbers[firstIndex];

            numbers[firstIndex] = numbers[secIndex];

            numbers[secIndex] = tempData;

            return numbers;
        }
    }
}
