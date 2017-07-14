using PawInc.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Centers
{
    public abstract class BaseCenter
    {
        private string name;
        private List<BaseAnimal> animals;

        public BaseCenter(string name)
        {
            this.Name = name;
            this.Animals = new List<BaseAnimal>();
        }

        public List<BaseAnimal> Animals
        {
            get { return this.animals; }
            protected set { this.animals = value; }
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }
    }
}