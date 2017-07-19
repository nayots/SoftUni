using Problem5_BorderControl.Interfaces;

namespace Problem5_BorderControl.Models
{
    public class Citizen : IBeing
    {
        public Citizen(string name, int age, string id)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
    }
}