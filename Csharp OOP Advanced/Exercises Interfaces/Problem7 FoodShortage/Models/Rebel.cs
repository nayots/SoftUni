using Problem7_FoodShortage.Interfaces;

namespace Problem7_FoodShortage.Models
{
    public class Rebel : IPerson
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public string Group { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}