using Problem1_EventImplementation.Models;
using System;

namespace Problem1_EventImplementation
{
    class Startup
    {
        private static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                dispatcher.Name = line;
            }
        }
    }
}