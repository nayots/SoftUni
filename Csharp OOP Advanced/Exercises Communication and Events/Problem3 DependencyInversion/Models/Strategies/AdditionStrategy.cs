namespace Problem3_DependencyInversion
{
    class AdditionStrategy : ICalculationStrategy
    {
        public AdditionStrategy()
        {
            this.Operator = '+';
        }

        public char Operator { get; private set; }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}