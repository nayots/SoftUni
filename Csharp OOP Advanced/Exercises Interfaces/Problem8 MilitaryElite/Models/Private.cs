namespace Problem8_MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public double Salary { get; protected set; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {this.Salary:F2}";
        }
    }
}