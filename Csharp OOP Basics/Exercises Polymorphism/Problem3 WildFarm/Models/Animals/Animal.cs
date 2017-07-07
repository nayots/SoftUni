using Problem3_WildFarm.Models.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        public Animal(string animalName, string animalType, double animalWeight)
        {
            this.AnimalName = animalName;
            this.AnimalType = animalType;
            this.AnimalWeight = animalWeight;
            this.FoodEaten = 0;
        }

        public int FoodEaten
        {
            get { return this.foodEaten; }
            protected set { this.foodEaten = value; }
        }

        public double AnimalWeight
        {
            get { return this.animalWeight; }
            protected set { this.animalWeight = value; }
        }

        public string AnimalType
        {
            get { return this.animalType; }
            protected set { this.animalType = value; }
        }

        public string AnimalName
        {
            get { return this.animalName; }
            protected set { this.animalName = value; }
        }

        public abstract void MakeSound();

        public abstract void Eat(Food food);
    }
}