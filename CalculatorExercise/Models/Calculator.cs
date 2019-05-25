using CalculatorExercise.Contracts;

namespace CalculatorExercise.Models
{
    public class Calculator : ICalculator
    {
        /// <summary>
        /// Used for addition for two numbers
        /// </summary>
        /// <param name="number1">Number 1</param>
        /// <param name="number2">Number 2</param>
        /// <returns></returns>
        public double Addition(double number1, double number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Used for division for two numbers
        /// </summary>
        /// <param name="number1">Number 1</param>
        /// <param name="number2">Number 2</param>
        /// <returns></returns>
        public double Division(double number1, double number2)
        {
            if (number2 == 0)
                return 0;

            return number1 / number2;
        }
    }
}
