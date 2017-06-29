using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12_Google
{
    public class Parent
    {
        public Parent(string name, string bday)
        {
            this.Name = name;
            this.Birthday = bday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}