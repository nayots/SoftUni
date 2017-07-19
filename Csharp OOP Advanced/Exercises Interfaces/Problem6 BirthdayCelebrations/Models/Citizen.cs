using Problem6_BirthdayCelebrations.Interfaces;

namespace Problem6_BirthdayCelebrations.Models
{
    public class Citizen : IBeing, INamable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
            this.BirthDate = birthdate;
        }

        public int Age { get; private set; }
        public string BirthDate { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
    }
}