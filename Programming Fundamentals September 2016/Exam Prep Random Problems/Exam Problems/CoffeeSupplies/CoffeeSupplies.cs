using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CoffeeSupplies
{
    class CoffeeSupplies
    {
        static void Main(string[] args)
        {
            string[] delimiters = Console.ReadLine().Split();


            string delimiterOne = delimiters[0];
            string delimiterTwo = delimiters[1];

            string command = Console.ReadLine();

            List<CoffeeDrinker> coffeeDrinkers = new List<CoffeeDrinker>();
            List<Coffee> coffeeTypes = new List<Coffee>();

            while (command != "end of info")
            {
                if (Regex.IsMatch(command, $"(\\w+)(?:{Regex.Escape(delimiterOne)})(\\w+)"))
                {
                    string[] personAndCoffee = Regex.Split(command, Regex.Escape(delimiterOne));

                    CoffeeDrinker drinker = new CoffeeDrinker
                    {
                        Name = personAndCoffee[0],
                        CoffeeType = new Coffee { Name = personAndCoffee[1] }
                    };
                    if (!coffeeTypes.Any(x => x.Name == drinker.CoffeeType.Name))
                    {
                        coffeeTypes.Add(new Coffee { Name = personAndCoffee[1] });
                    }

                    coffeeDrinkers.Add(drinker);
                }
                else
                {
                    string[] coffeeAndQuantity = Regex.Split(command, Regex.Escape(delimiterTwo));

                    Coffee coffee = new Coffee
                    {
                        Name = coffeeAndQuantity[0],
                        Quantity = int.Parse(coffeeAndQuantity[1])
                    };

                    if (coffeeTypes.Any(x => x.Name == coffee.Name))
                    {
                        var indx = coffeeTypes.FindIndex(x => x.Name == coffee.Name);

                        coffeeTypes[indx].Quantity += coffee.Quantity;
                    }
                    else
                    {
                        coffeeTypes.Add(coffee);
                    }
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            foreach (var cof in coffeeTypes.Where(x => x.Quantity <= 0))
            {
                Console.WriteLine($"Out of {cof.Name}");
            }

            while (command != "end of week")
            {
                string[] personAndCoffeCups = command.Split();
                string person = personAndCoffeCups[0];
                int cups = int.Parse(personAndCoffeCups[1]);

                int indxP = coffeeDrinkers.FindIndex(x => x.Name == person);

                string coffeeName = coffeeDrinkers[indxP].CoffeeType.Name;

                int indxC = coffeeTypes.FindIndex(x => x.Name == coffeeName);


                coffeeTypes[indxC].Quantity -= cups;
                if (coffeeTypes[indxC].Quantity <= 0)
                {
                    Console.WriteLine($"Out of {coffeeName}");
                }



                command = Console.ReadLine();
            }
            List<string> coffeeNames = new List<string>();

            Console.WriteLine("Coffee Left:");
            foreach (var c in coffeeTypes.Where(x => x.Quantity > 0).OrderByDescending(x => x.Quantity))
            {
                Console.WriteLine($"{c.Name} {c.Quantity}");
                coffeeNames.Add(c.Name);
            }

            var endResults = new List<CoffeeDrinker>();

            foreach (var cName in coffeeNames)
            {
                foreach (var drinker in coffeeDrinkers)
                {
                    if (drinker.CoffeeType.Name == cName)
                    {
                        endResults.Add(drinker);
                    }
                }
            }

            Console.WriteLine("For:");

            foreach (var drinker in endResults.OrderBy(x => x.CoffeeType.Name).ThenByDescending(p => p.Name))
            {
                //{personName} {coffeeType}
                Console.WriteLine($"{drinker.Name} {drinker.CoffeeType.Name}");
            }
        }
    }

    class CoffeeDrinker
    {
        public string Name { get; set; }
        public Coffee CoffeeType { get; set; }
    }

    class Coffee
    {
        public string Name { get; set; }
        public int Quantity { get; set; } = 0;
    }
}
