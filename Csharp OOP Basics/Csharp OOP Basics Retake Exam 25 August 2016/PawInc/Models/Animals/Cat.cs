using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Animals
{
    public class Cat : BaseAnimal
    {
        private int intelligence;

        public Cat(string name, int age, int intelligence, string adoptionCenterName) : base(name, age, adoptionCenterName)
        {
            this.Intelligence = intelligence;
        }

        public int Intelligence
        {
            get { return this.intelligence; }
            set { this.intelligence = value; }
        }
    }
}