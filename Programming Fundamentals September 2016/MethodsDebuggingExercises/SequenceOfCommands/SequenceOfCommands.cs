using System;
using System.Linq;
//17. Sequence of Commands
public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string command = Console.ReadLine();

        while (!command.Equals("stop"))
        {
            string line = command.Trim();
            int[] args = new int[2];
            string[] stringParams = line.Split(ArgumentsDelimiter);
            if (stringParams[0].Equals("add") ||
                stringParams[0].Equals("subtract") ||
                stringParams[0].Equals("multiply"))
            {
                args[0] = int.Parse(stringParams[1]);
                args[1] = int.Parse(stringParams[2]);

                PrintArray(PerformAction(array, stringParams[0], args));
            }
            else
            {
                PrintArray(PerformAction(array, stringParams[0], args));
            }
            array = PerformAction(array, stringParams[0], args);
            Console.WriteLine();

            command = Console.ReadLine();
        }
    }

    static long[] PerformAction(long[] arr, string action, int[] args)
    {
        long[] array = arr.Clone() as long[];
        int pos = args[0] - 1;
        int value = args[1];

        switch (action)
        {
            case "multiply":
                array[pos] *= value;
                break;
            case "add":
                array[pos] += value;
                break;
            case "subtract":
                array[pos] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(array);
                break;
            case "rshift":
                ArrayShiftRight(array);
                break;
        }
        return array;
    }

    private static void ArrayShiftRight(long[] array)
    {
        long lastDigit = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (i > 0)
            {
                array[i] = array[i - 1];
            }
            else
            {
                array[i] = lastDigit;
            }
            
        }
    }

    private static void ArrayShiftLeft(long[] array)
    {
        long firstDigit = array[0];
        for (int i = 0; i <= array.Length - 1; i++)
        {
            if (i < array.Length - 1)
            {
                array[i] = array[i + 1];
            }
            else
            {
                array[i] = firstDigit;
            }
        }
    }

    private static void PrintArray(long[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
    }
}
