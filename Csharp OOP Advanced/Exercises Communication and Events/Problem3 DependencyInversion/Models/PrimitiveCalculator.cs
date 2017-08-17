using System.Collections.Generic;
using System.Linq;

namespace Problem3_DependencyInversion
{
    class PrimitiveCalculator
    {
        private bool isAddition;
        private ICalculationStrategy currentStrategy;
        private IList<ICalculationStrategy> calculatorStrategies;

        public PrimitiveCalculator()
        {
            ICalculationStrategy addition = new AdditionStrategy();

            this.calculatorStrategies = new List<ICalculationStrategy>
            {
                addition,
                new SubtractionStrategy(),
                new MultiplicationStrategy(),
                new DivisionStrategy()
            };
            this.currentStrategy = addition;
        }

        public void ChangeStrategy(char @operator)
        {
            ICalculationStrategy strategy = this.calculatorStrategies.FirstOrDefault(s => s.Operator == @operator);
            if (strategy != null)
            {
                this.currentStrategy = strategy;
            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.currentStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}