using CustomList.Models.Generics;
using System;
using System.Linq;

namespace CustomList.Core
{
    public class CommandInterpreter
    {
        private CustomizedList<string> list;

        public CommandInterpreter()
        {
            this.list = new CustomizedList<string>();
        }

        public void ProcessInput()
        {
            var inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var command = tokens[0];
                tokens.Remove(tokens.First());

                switch (command)
                {
                    case "Add":
                        this.list.Add(tokens[0]);
                        break;

                    case "Remove":
                        this.list.Remove(int.Parse(tokens[0]));
                        break;

                    case "Contains":
                        Console.WriteLine(this.list.Contains(tokens[0]));
                        break;

                    case "Swap":
                        this.list.Swap(int.Parse(tokens[0]), int.Parse(tokens[1]));
                        break;

                    case "Greater":
                        Console.WriteLine(this.list.CountGreaterThan(tokens[0]));
                        break;

                    case "Max":
                        Console.WriteLine(this.list.Max());
                        break;

                    case "Min":
                        Console.WriteLine(this.list.Min());
                        break;

                    case "Print":
                        foreach (var item in this.list)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case "Sort":
                        this.list.Sort();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}