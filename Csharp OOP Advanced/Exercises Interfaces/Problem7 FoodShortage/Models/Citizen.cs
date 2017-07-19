using Problem7_FoodShortage.Interfaces;

namespace Problem7_FoodShortage.Models
{
    public class Citizen : IBeing, IBirthable, IPerson
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthdate;
            this.Food = 0;
        }

        public int Age { get; private set; }
        public string BirthDate { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}