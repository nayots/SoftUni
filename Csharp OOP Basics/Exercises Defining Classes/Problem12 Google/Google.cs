using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12_Google
{
    class Google
    {
        private static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            var input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var personName = tokens[0];

                if (!people.Any(p => p.Name == personName))
                {
                    people.Add(new Person(personName));
                }

                var person = people.FirstOrDefault(p => p.Name == personName);

                var command = tokens[1];
                switch (command)
                {
                    case "company":
                        var cName = tokens[2];
                        var cDep = tokens[3];
                        var salary = decimal.Parse(tokens[4]);
                        Company comp = new Company(cName, cDep, salary);
                        person.Company = comp;
                        break;

                    case "pokemon":
                        var pName = tokens[2];
                        var pType = tokens[3];
                        Pokemon poke = new Pokemon(pName, pType);
                        person.Pokemons.Add(poke);
                        break;

                    case "parents":
                        var paName = tokens[2];

                        Parent par = new Parent(paName, tokens[3]);
                        person.Parents.Add(par);
                        break;

                    case "children":
                        var chName = tokens[2];

                        Child child = new Child(chName, tokens[3]);
                        person.Children.Add(child);
                        break;

                    case "car":
                        var carModel = tokens[2];
                        var carSpeed = int.Parse(tokens[3]);
                        Car car = new Car(carModel, carSpeed);
                        person.Car = car;
                        break;
                }
            }

            input = Console.ReadLine();

            var pers = people.FirstOrDefault(p => p.Name == input);

            Console.Write(pers.ToString());
        }
    }
}