using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6_Truck_Tour
{
    internal class TruckTour
    {
        private static Queue<Station> stations = new Queue<Station>();
        private static long stationsCount;

        private static void Main(string[] args)
        {
            stationsCount = long.Parse(Console.ReadLine());

            for (int i = 0; i < stationsCount; i++)
            {
                long[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

                stations.Enqueue(new Station(inputArgs[0], inputArgs[1]));
            }

            for (int i = 0; i < stationsCount; i++)
            {
                if (StationIsValidStartPoint())
                {
                    Console.WriteLine(i);
                    break;
                }

                var st = stations.Dequeue();
                stations.Enqueue(st);
            }
        }

        private static bool StationIsValidStartPoint()
        {
            long fuelTank = 0;
            bool stationFound = true;
            for (int i = 0; i < stationsCount; i++)
            {
                var currStation = stations.Dequeue();
                fuelTank += currStation.Gas - currStation.Distance;
                if (fuelTank < 0)
                {
                    stationFound = false;
                }
                stations.Enqueue(currStation);
            }

            return stationFound;
        }
    }

    internal class Station
    {
        public Station(long gas, long distance)
        {
            this.Gas = gas;
            this.Distance = distance;
        }

        public long Gas { get; set; }
        public long Distance { get; set; }
    }
}