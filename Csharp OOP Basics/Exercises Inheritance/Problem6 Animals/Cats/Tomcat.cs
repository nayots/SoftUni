using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_Animals.Cats
{
    public class Tomcat : Animal
    {
        public Tomcat(string name, int age) : base(name, age, "Male")
        {
        }

        public override string ProduceSound()
        {
            return "Give me one million b***h";
        }
    }
}