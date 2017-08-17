namespace Problem3_DependencyInversion
{
    public class DivisionStrategy : ICalculationStrategy
    {
        public DivisionStrategy()
        {
            this.Operator = '/';
        }

        public char Operator { get; private set; }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}