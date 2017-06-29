using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SpeedRacing
{
    public static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var model = tokens[0];
            var fa = double.Parse(tokens[1]);
            var fc = double.Parse(tokens[2]);
            cars.Add(new Car(model, fa, fc));
        }

        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var arguments = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var model = arguments[1];
            int km = int.Parse(arguments[2]);

            var car = cars.First(x => x.Model == model);
            car.TryExecuteTrip(km);
        }

        foreach (var c in cars)
        {
            Console.WriteLine($"{c.Model} {c.FuelAmount:F2} {c.DistanceTraveled}");
        }
    }
}