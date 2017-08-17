namespace Problem3_DependencyInversion
{
    class SubtractionStrategy : ICalculationStrategy
    {
        public SubtractionStrategy()
        {
            this.Operator = '-';
        }

        public char Operator { get; private set; }

        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}