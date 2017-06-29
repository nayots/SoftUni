using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RawData
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = tokens[0];
            int eSpeed = int.Parse(tokens[1]);
            int ePower = int.Parse(tokens[2]);
            int cWeight = int.Parse(tokens[3]);
            string cType = tokens[4];
            double tire1Pressure = double.Parse(tokens[5]);
            int tire1Age = int.Parse(tokens[6]);
            double tire2Pressure = double.Parse(tokens[7]);
            int tire2Age = int.Parse(tokens[8]);
            double tire3Pressure = double.Parse(tokens[9]);
            int tire3Age = int.Parse(tokens[10]);
            double tire4Pressure = double.Parse(tokens[11]);
            int tire4Age = int.Parse(tokens[12]);

            List<Tire> tires = new List<Tire>();
            tires.Add(new Tire(tire1Age, tire1Pressure));
            tires.Add(new Tire(tire2Age, tire2Pressure));
            tires.Add(new Tire(tire3Age, tire3Pressure));
            tires.Add(new Tire(tire4Age, tire4Pressure));

            Car car = new Car
                (
                model,
                new Engine(eSpeed, ePower),
                new Cargo(cWeight, cType),
                tires
                );

            cars.Add(car);
        }

        var command = Console.ReadLine();

        if (command == "fragile")
        {
            var results = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));

            foreach (var res in results)
            {
                Console.WriteLine(res.Model);
            }
        }
        else if (command == "flamable")
        {
            var results = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);

            foreach (var res in results)
            {
                Console.WriteLine(res.Model);
            }
        }
    }
}