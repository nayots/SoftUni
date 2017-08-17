namespace Problem3_DependencyInversion
{
    public class MultiplicationStrategy : ICalculationStrategy
    {
        public MultiplicationStrategy()
        {
            this.Operator = '*';
        }

        public char Operator { get; private set; }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }
}