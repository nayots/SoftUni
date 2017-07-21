using System;
using System.Collections.Generic;
using System.Linq;
using Threeuple.Models.Generics;

namespace Threeuple
{
    class Startup
    {
        private static void Main(string[] args)
        {
            List<string> tokens = GetTokens();

            Threeuple<string, string, string> threeupleOne = new Threeuple<string, string, string>((tokens[0] + " " + tokens[1]), tokens[2], tokens[3]);

            tokens = GetTokens();

            Threeuple<string, int, bool> threeupleTwo = new Threeuple<string, int, bool>(tokens[0], int.Parse(tokens[1]), tokens[2] == "drunk" ? true : false);

            tokens = GetTokens();

            Threeuple<string, double, string> threeupleThree = new Threeuple<string, double, string>(tokens[0], double.Parse(tokens[1]), tokens[2]);

            Console.WriteLine(threeupleOne);
            Console.WriteLine(threeupleTwo);
            Console.WriteLine(threeupleThree);
        }

        private static List<string> GetTokens()
        {
            return Console.ReadLine().Split().ToList();
        }
    }
}