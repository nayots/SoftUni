using System;
using System.Net;

namespace Problem2_ValidateUrl
{
    class Startup
    {
        private const string InvalidUrlMessage = "Invalid URL";

        private static void Main(string[] args)
        {
            string url = Console.ReadLine();

            url = WebUtility.UrlDecode(url);

            Uri uri = new Uri(url);

            if (string.IsNullOrEmpty(uri.Scheme) || string.IsNullOrEmpty(uri.Host) || string.IsNullOrEmpty(uri.AbsolutePath) || uri.Port < 0)
            {
                Console.WriteLine(InvalidUrlMessage);
            }
            else
            {
                Console.WriteLine($"Protocol: {uri.Scheme}");
                Console.WriteLine($"Host: {uri.Host}");
                Console.WriteLine($"Port: {uri.Port}");
                Console.WriteLine($"Path: {uri.AbsolutePath}");

                if (!string.IsNullOrEmpty(uri.Query))
                {
                    Console.WriteLine($"Query: {uri.Query}");
                }
                if (!string.IsNullOrEmpty(uri.Fragment))
                {
                    Console.WriteLine($"Fragment: {uri.Fragment}");
                }
            }
        }
    }
}