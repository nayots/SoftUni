using Problem4_WorkForce.Models.Contracts;

namespace Problem4_WorkForce.Models
{
    public class PartTimeEmployee : IEmployee
    {
        public PartTimeEmployee(string name)
        {
            this.Name = name;
            this.WorkHours = 20;
        }

        public string Name { get; private set; }

        public int WorkHours { get; private set; }
    }
}