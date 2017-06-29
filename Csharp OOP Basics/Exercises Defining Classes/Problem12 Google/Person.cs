using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12_Google
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
        public ICollection<Parent> Parents { get; set; }
        public ICollection<Child> Children { get; set; }
        public Car Car { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.Name);
            sb.AppendLine($"Company:");
            if (this.Company != null)
            {
                sb.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
            }
            sb.AppendLine($"Car:");
            if (this.Car != null)
            {
                sb.AppendLine($"{this.Car.Model} {this.Car.Speed}");
            }
            sb.AppendLine($"Pokemon:");
            foreach (var poke in this.Pokemons)
            {
                sb.AppendLine($"{poke.Name} {poke.Type}");
            }
            sb.AppendLine($"Parents:");
            foreach (var p in this.Parents)
            {
                sb.AppendLine($"{p.Name} {p.Birthday}");
            }
            sb.AppendLine($"Children:");
            foreach (var c in this.Children)
            {
                sb.AppendLine($"{c.Name} {c.Birthday}");
            }
            return sb.ToString();
        }
    }
}