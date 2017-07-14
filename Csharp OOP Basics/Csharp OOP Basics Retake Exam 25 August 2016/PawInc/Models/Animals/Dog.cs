using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Animals
{
    public class Dog : BaseAnimal
    {
        private int commands;

        public Dog(string name, int age, int commands, string adoptionCenterName) : base(name, age, adoptionCenterName)
        {
            this.Commands = commands;
        }

        public int Commands
        {
            get { return this.commands; }
            private set { this.commands = value; }
        }
    }
}