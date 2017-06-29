using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10_CarSalesman
{
    class CarSalesman
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];
                var power = int.Parse(tokens[1]);

                var engine = new Engine(model, power);

                if (tokens.Length > 2)
                {
                    int disp = 0;
                    if (int.TryParse(tokens[2], out disp))
                    {
                        engine.Displacement = disp;
                        if (tokens.Length > 3)
                        {
                            engine.Efficiency = tokens[3];
                        }
                    }
                    else
                    {
                        engine.Efficiency = tokens[2];
                    }
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int j = 0; j < m; j++)
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = tokens[0];
                var engine = engines.FirstOrDefault(e => e.Model == tokens[1]);

                Car car = new Car(model, engine);

                if (tokens.Length > 2)
                {
                    int weight = 0;
                    if (int.TryParse(tokens[2], out weight))
                    {
                        car.Weight = weight;
                        if (tokens.Length > 3)
                        {
                            car.Color = tokens[3];
                        }
                    }
                    else
                    {
                        car.Color = tokens[2];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.Write(car.ToString());
            }
        }
    }
}