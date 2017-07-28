using System;
using System.Collections.Generic;
using TrafficLights.Interfaces;
using TrafficLights.Models;

namespace TrafficLights
{
    class Startup
    {
        private static void Main(string[] args)
        {
            string[] initialLights = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<ITrafficLight> trafficLights = new List<ITrafficLight>();

            foreach (var light in initialLights)
            {
                trafficLights.Add(new TrafficLight(light));
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                trafficLights.ForEach(l => l.Cycle());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}