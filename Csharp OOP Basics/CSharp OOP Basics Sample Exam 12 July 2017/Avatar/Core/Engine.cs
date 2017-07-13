using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private NationsBuilder builder;

    public Engine()
    {
        this.builder = new NationsBuilder();
    }

    public void Run()
    {
        var tokens = ParseInput(Console.ReadLine());

        string command = string.Empty;

        while ((command = tokens[0]) != "Quit")
        {
            ProcessCommand(command, tokens.Skip(1).ToList());

            tokens = ParseInput(Console.ReadLine());
        }

        Console.WriteLine(builder.GetWarsRecord());
    }

    private void ProcessCommand(string command, List<string> commandArgs)
    {
        switch (command)
        {
            case "Bender":
                builder.AssignBender(commandArgs);
                break;

            case "Monument":
                builder.AssignMonument(commandArgs);
                break;

            case "Status":
                Console.Write(builder.GetStatus(commandArgs.First()));
                break;

            case "War":
                builder.IssueWar(commandArgs.First());
                break;

            default:
                break;
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}