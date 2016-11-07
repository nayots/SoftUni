using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//02. Ladybugs
namespace Ladybugs
{
    class Ladybugs
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            long[] indexes = Console.ReadLine().Split().Select(long.Parse).ToArray();
            long[] bugField = new long[fieldSize];


            foreach (var index in indexes)
            {
                if (index >= 0 && index < bugField.Length)
                {
                    bugField[index] = 1;
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandInfo = command.Split();

                long ladyBugIndx = long.Parse(commandInfo[0]);
                string direction = commandInfo[1];
                long flyLength = long.Parse(commandInfo[2]);

                if (ladyBugIndx <= bugField.Length - 1 && ladyBugIndx >= 0)
                {
                    if (bugField[ladyBugIndx] == 1)
                    {
                        switch (direction)
                        {
                            case "right":
                                bugField = MoveLbRight(bugField, ladyBugIndx, flyLength);
                                break;
                            case "left":
                                bugField = MoveLbLeft(bugField, ladyBugIndx, flyLength);
                                break;
                        }
                    }
                }
                //Console.WriteLine(string.Join(" ", bugField));
                command = Console.ReadLine();
            }

            if (bugField.Length > 0)
            {
                Console.WriteLine(string.Join(" ", bugField));
            }
        }

        private static long[] MoveLbLeft(long[] bugField, long ladyBugIndx, long flyLength)
        {
            long takeOffIndex = ladyBugIndx;
            long flight = takeOffIndex - flyLength;
            long landIndex = ladyBugIndx;
            if (flyLength == 0)
            {
                return bugField;
            }
            if (flyLength < 0)
            {
                bugField = MoveLbRight(bugField, ladyBugIndx, Math.Abs(flyLength));
                return bugField;
            }
            if (flight >= 0 && flight < bugField.Length)// To check later
            {

                if (bugField[flight] == 0)
                {
                    landIndex = flight;

                    bugField[takeOffIndex] = 0;
                    bugField[landIndex] = 1;
                }
                else
                {
                    landIndex = -1;
                    for (long i = flight; i >= 0; i -= flyLength)
                    {
                        if (bugField[i] != 1)
                        {
                            landIndex = i;
                            bugField[takeOffIndex] = 0;
                            bugField[landIndex] = 1;
                            break;
                        }

                    }
                    if (landIndex < 0)
                    {
                        bugField[takeOffIndex] = 0;
                    }
                }
            }
            else
            {
                bugField[takeOffIndex] = 0;
            }
            return bugField;
        }

        private static long[] MoveLbRight(long[] bugField, long ladyBugIndx, long flyLength)
        {

            long takeOffIndex = ladyBugIndx;
            long flight = takeOffIndex + flyLength;
            long landIndex = ladyBugIndx;
            if (flyLength == 0)
            {
                return bugField;
            }
            if (flyLength < 0)
            {
                bugField = MoveLbLeft(bugField, ladyBugIndx, Math.Abs(flyLength));
                return bugField;
            }
            if (flight >= 0 && flight < bugField.Length)// To check later
            {

                if (bugField[flight] == 0)
                {
                    landIndex = flight;

                    bugField[takeOffIndex] = 0;
                    bugField[landIndex] = 1;
                }
                else
                {
                    landIndex = -1;
                    for (long i = flight; i < bugField.Length; i += flyLength)
                    {
                        if (bugField[i] != 1)
                        {
                            landIndex = i;
                            bugField[takeOffIndex] = 0;
                            bugField[landIndex] = 1;
                            break;
                        }

                    }
                    if (landIndex < 0)
                    {
                        bugField[takeOffIndex] = 0;
                    }
                }
            }
            else
            {
                bugField[takeOffIndex] = 0;
            }
            return bugField;
        }
    }
}
