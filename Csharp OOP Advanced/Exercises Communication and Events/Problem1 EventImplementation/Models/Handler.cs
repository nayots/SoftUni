using System;

namespace Problem1_EventImplementation.Models
{
    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}