using System;
using System.Collections.Generic;

namespace Problem3_RequestParser
{
    class Startup
    {
        private const int NotFoundCode = 404;
        private const string NotFoundCodeMessage = "Not Found";
        private const int OKStatusCode = 200;
        private const string OkStatusCodeMessage = "OK";

        private static void Main(string[] args)
        {
            var validUrls = new Dictionary<string, HashSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                string path = $"/{tokens[0]}";
                string method = tokens[1];

                if (!validUrls.ContainsKey(path))
                {
                    validUrls[path] = new HashSet<string>();
                }

                validUrls[path].Add(method);
            }

            string request = Console.ReadLine();

            string[] requestParts = request.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string rMethod = requestParts[0].ToLower();
            string rPath = requestParts[1];
            string rProtocol = requestParts[2];

            if (validUrls.ContainsKey(rPath) && validUrls[rPath].Contains(rMethod))
            {
                Console.WriteLine($"{rProtocol} {OKStatusCode} {OkStatusCodeMessage}");
                Console.WriteLine($"Content-Length: {OkStatusCodeMessage.Length}");
                Console.WriteLine($"Content-Type: text/plain");
                Console.WriteLine($"{Environment.NewLine}{OkStatusCodeMessage}");
            }
            else
            {
                Console.WriteLine($"{rProtocol} {NotFoundCode} {NotFoundCodeMessage}");
                Console.WriteLine($"Content-Length: {NotFoundCodeMessage.Length}");
                Console.WriteLine($"Content-Type: text/plain");
                Console.WriteLine($"{Environment.NewLine}{NotFoundCodeMessage}");
            }
        }
    }
}