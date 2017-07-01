using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_ShoppingSpree
{
    class ShoppingSpree
    {
        private static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();

            try
            {
                var peopleInfo = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in peopleInfo)
                {
                    var nameAndMoney = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    people.Add(new Person(nameAndMoney[0], decimal.Parse(nameAndMoney[1])));
                }
                var productInfo = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in productInfo)
                {
                    var nameAndCost = token.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                    products.Add(new Product(nameAndCost[0], decimal.Parse(nameAndCost[1])));
                }
                var input = string.Empty;
                while ((input = Console.ReadLine()) != "END")
                {
                    var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var personName = tokens[0];
                    var productName = tokens[1];

                    var person = people.First(p => p.Name == personName);
                    var product = products.First(p => p.Name == productName);

                    if (person.Money - product.Cost >= 0)
                    {
                        person.Products.Add(product);
                        person.Money -= product.Cost;
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }

                foreach (var p in people)
                {
                    string productMsg = p.Products.Count > 0 ? string.Join(", ", p.Products.Select(pr => pr.Name)) : "Nothing bought";

                    Console.WriteLine($"{p.Name} - " + productMsg);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}