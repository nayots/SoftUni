using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12_Google
{
    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            this.Name = name;
            this.Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}