using System;
using System.Collections.Generic;
using System.Linq;
//02. Advertisement Message
namespace AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            Message ad = new Message();
            for (int i = 0; i < n; i++)
            {
                int pRandom = rnd.Next(ad.phrases.Length);
                int eRandom = rnd.Next(ad.events.Length);
                int aRandom = rnd.Next(ad.author.Length);
                int cRandom = rnd.Next(ad.cities.Length);

                Console.WriteLine($"{ad.phrases[pRandom]} {ad.events[eRandom]} {ad.author[aRandom]} – {ad.cities[cRandom]}.");
            }
        }
    }

    class Message
    {
        public string[] phrases
        {
            get
            {
                return new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            }
        }

        public string[] events
        {
            get
            {
                return new string[] {"Now I feel good.", "I have succeeded with this product.", "Makes miracles.I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
            }
        }

        public string[] author
        {
            get
            {
                return new string[] {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            }
        }

        public string[] cities
        {
            get
            {
                return new string[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};
            }
        }
    }
}
