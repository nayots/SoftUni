using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private DraftManager manager;

    public Engine()
    {
        this.manager = new DraftManager();
    }

    public void Run()
    {
        string input = Console.ReadLine();

        while (input != "Shutdown")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(tokens.Skip(1).ToList()));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(tokens.Skip(1).ToList()));
                    break;

                case "Day":
                    Console.WriteLine(manager.Day());
                    break;

                case "Mode":
                    Console.WriteLine(manager.Mode(tokens.Skip(1).ToList()));
                    break;

                case "Check":
                    Console.WriteLine(manager.Check(tokens.Skip(1).ToList()));
                    break;

                default:
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(manager.ShutDown());
    }
}