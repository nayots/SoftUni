using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem3_WildFarm.Models.Foods;

namespace Problem3_WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private string breed;

        public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string catBreed) : base(animalName, animalType, animalWeight, livingRegion)
        {
            this.Breed = catBreed;
        }

        public string Breed
        {
            get { return this.breed; }
            private set { this.breed = value; }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}