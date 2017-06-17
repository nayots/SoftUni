using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem13_OfficeStuff
{
    class OfficeStuff
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\|(\w+)\s-\s(\d+)\s-\s(\w+)\|";
            Regex rgx = new Regex(pattern);
            List<Stuff> stuff = new List<Stuff>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var match = rgx.Match(input);

                stuff.Add(new Stuff(match.Groups[1].Value, int.Parse(match.Groups[2].Value), match.Groups[3].Value));
            }

            var res = stuff.GroupBy(s => s.Company, s =>
                new { Amount = s.Amount, Product = s.Product },
                    (company, products) =>
                        new
                        {
                            Company = company,
                            Products = products
                                        .GroupBy(z => z.Product, z => z.Amount,
                                        (prod, amounts) =>
                                        new
                                        {
                                            Product = prod,
                                            Sum = amounts.Sum()
                                        })
                        }).ToList();

            foreach (var comp in res.OrderBy(x => x.Company))
            {
                Console.WriteLine($"{comp.Company}: {string.Join(", ", comp.Products.Select(x => x.Product + "-" + x.Sum.ToString()))}");
            }
        }
    }

    class Stuff
    {
        public Stuff(string company, int amount, string product)
        {
            this.Company = company;
            this.Amount = amount;
            this.Product = product;
        }

        public string Company { get; set; }
        public int Amount { get; set; }
        public string Product { get; set; }
    }
}