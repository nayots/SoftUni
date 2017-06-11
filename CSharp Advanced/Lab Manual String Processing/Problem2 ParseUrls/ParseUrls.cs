using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_ParseUrls
{
    class ParseUrls
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string[] reminder = input.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

            if (reminder.Length > 2 || reminder.Length < 2)
            {
                Console.WriteLine("Invalid URL");
                return;
            }

            string protocol = reminder[0];

            int serverEndIndex = reminder[1].IndexOf("/");

            if (serverEndIndex < 0)
            {
                Console.WriteLine("Invalid URL");
                return;
            }
            string server = reminder[1].Substring(0, serverEndIndex);

            string resource = reminder[1].Substring(serverEndIndex + 1);

            Console.WriteLine($"Protocol = {protocol}");
            Console.WriteLine($"Server = {server}");
            Console.WriteLine($"Resources = {resource}");
        }
    }
}