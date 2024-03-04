
using Task0;

namespace TestTask0
{



    [TestFixture]
    public class SumCalculatorTests
    {
        [Test]
        public void CalculateSum_Input3and2_Returns5()
        {
            // Arrange
            var calculator = new SumCalculator();
            int number1 = 3;
            int number2 = 2;
            int expectedResult = 5;

            // Act
            var result = calculator.CalculateSum(number1, number2);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculateSum_InputNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var calculator = new SumCalculator();
            int number1 = -5;
            int number2 = -7;
            int expectedResult = -12;

            // Act
            var result = calculator.CalculateSum(number1, number2);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}