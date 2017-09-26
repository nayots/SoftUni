using System;
using System.Net;

namespace Problem1_URLDecode
{
    class Startup
    {
        private static void Main(string[] args)
        {
            string url = Console.ReadLine();

            string decodedUrl = WebUtility.UrlDecode(url);

            Console.WriteLine(decodedUrl);
        }
    }
}