using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//02. Command Interpreter
namespace CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> lines = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string commandLine = Console.ReadLine();

            while (commandLine != "end")
            {
                string[] commands = commandLine.Split();
                string instruction = commands[0];
                long start = 0;
                long count = 0;
                if (instruction == "reverse" || instruction == "sort")
                {
                    start = long.Parse(commands[2]);
                    count = long.Parse(commands[4]);

                    if (start < 0 || start > lines.Count - 1 || count + start > lines.Count || count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        lines = ProcessString(lines, start, count, instruction);
                    }
                }
                else
                {
                    count = long.Parse(commands[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        lines = Roll(lines, count, instruction);
                    }
                }
                commandLine = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", lines)}]");
        }

        private static List<string> ProcessString(List<string> lines, long start, long count, string instruction)
        {

            List<string> leftPart = lines.Take((int)start).ToList();
            List<string> rightPart = lines.Skip((int)(start + count)).ToList();
            List<string> toTreat = lines.Skip((int)start).Take((int)count).ToList();

            if (instruction == "reverse")
            {
                toTreat.Reverse();
            }
            else if (instruction == "sort")
            {
                toTreat.Sort();
            }

            List<string> treated = new List<string>();
            treated.AddRange(leftPart);
            treated.AddRange(toTreat);
            treated.AddRange(rightPart);
            return treated;
        }


        private static List<string> Roll(List<string> lines, long count, string instruction)
        {
            count = count % lines.Count;

            for (int i = 0; i < count; i++)
            {
                List<string> toRoll = new List<string>();
                List<string> toMove = new List<string>();

                if (instruction == "rollRight")
                {
                    toRoll = lines.Take(lines.Count() - 1).ToList();
                    toMove = lines.Skip(toRoll.Count()).ToList();
                }
                else
                {
                    toRoll = lines.Take(1).ToList();
                    toMove = lines.Skip(1).ToList();
                }

                List<string> temp = new List<string>();
                temp.AddRange(toMove);
                temp.AddRange(toRoll);
                lines = temp;
            }

            return lines;
        }
    }
}