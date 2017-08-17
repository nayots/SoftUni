using Problem4_WorkForce.Models.Contracts;

namespace Problem4_WorkForce.Models
{
    public class StandartEmployee : IEmployee
    {
        public StandartEmployee(string name)
        {
            this.Name = name;
            this.WorkHours = 40;
        }

        public string Name { get; private set; }

        public int WorkHours { get; private set; }
    }
}