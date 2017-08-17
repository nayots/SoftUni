namespace Problem3_DependencyInversion
{
    internal interface ICalculationStrategy
    {
        char Operator { get; }

        int Calculate(int firstOperand, int secondOperand);
    }
}