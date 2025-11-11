using Tut2_s30472;

namespace Tut2_s30472_Tests
{
    public class CalculatorTests
    {
        [TestCase(5, 3, '+', ExpectedResult = 8)]
        [TestCase(5, 3, '-', ExpectedResult = 2)]
        [TestCase(5, 3, '*', ExpectedResult = 15)]
        [TestCase(6, 3, '/', ExpectedResult = 2)]
        public double TestBasicOperations(double a, double b, char op)
        {
            var calc = new Calculator(a, b, op);
            return calc.Calculate();
        }

        [Test]
        public void TestDivisionByZero()
        {
            var calc = new Calculator(5, 0, '/');
            Assert.Throws<DivideByZeroException>(() => calc.Calculate());
        }

        [Test]
        public void TestInvalidOperation()
        {
            var calc = new Calculator(5, 5, '%');
            Assert.Throws<InvalidOperationException>(() => calc.Calculate());
        }

        [TestCase(-5, 3, '+', ExpectedResult = -2)]
        [TestCase(-5, -3, '*', ExpectedResult = 15)]
        [TestCase(0, 0, '+', ExpectedResult = 0)]
        [TestCase(0, 5, '*', ExpectedResult = 0)]
        public double TestEdgeCases(double a, double b, char op)
        {
            var calc = new Calculator(a, b, op);
            return calc.Calculate();
        }

        [Test]
        public void TestNaNOperands()
        {
            var calc1 = new Calculator(double.NaN, 5, '+');
            Assert.Throws<ArgumentException>(() => calc1.Calculate());
            var calc2 = new Calculator(5, double.NaN, '*');
            Assert.Throws<ArgumentException>(() => calc2.Calculate());
        }

        [Test]
        public void TestInfinityOperands()
        {
            var calc1 = new Calculator(double.PositiveInfinity, 5, '+');
            Assert.Throws<ArgumentException>(() => calc1.Calculate());
            var calc2 = new Calculator(5, double.NegativeInfinity, '*');
            Assert.Throws<ArgumentException>(() => calc2.Calculate());
        }

        [Test]
        public void TestOverflow()
        {
            var calc = new Calculator(1e308, 1e308, '+');
            Assert.Throws<OverflowException>(() => calc.Calculate());
            var calc2 = new Calculator(1e154, 1e154, '*');
            Assert.Throws<OverflowException>(() => calc2.Calculate());
        }
    }
}
