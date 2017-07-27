using Problem2_Collection.Models.Generics;
using System;
using System.Linq;

namespace Problem2_Collection
{
    class Startup
    {
        private static void Main(string[] args)
        {
            string input = string.Empty;

            ListlyIterator<string> listly = null;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = tokens[0];
                try
                {
                    switch (command)
                    {
                        case "Create":
                            listly = new ListlyIterator<string>(tokens.Skip(1));
                            break;

                        case "Move":
                            Console.WriteLine(listly.Move());
                            break;

                        case "Print":
                            listly.Print();
                            break;

                        case "HasNext":
                            Console.WriteLine(listly.HasNext());
                            break;

                        case "PrintAll":
                            Console.WriteLine(string.Join(" ", listly));
                            break;

                        default:
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}