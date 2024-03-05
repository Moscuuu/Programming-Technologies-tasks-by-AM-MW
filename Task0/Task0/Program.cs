
using System;

namespace Task0
{
    public class SumCalculator
    {
        public int CalculateSum(int number1, int number2)
        {
            return number1 + number2;
        }
    }
    class Program
    {
        static void Main()
        {
            var calculator = new SumCalculator();
            Console.WriteLine("Enter the first number:");
            int number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int number2 = Convert.ToInt32(Console.ReadLine());
            int result = calculator.CalculateSum(number1, number2);
            Console.WriteLine($"The sum of {number1} and {number2} is {result}.");
        }
    }
}