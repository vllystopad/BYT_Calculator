namespace Tut2_s30472
{
    public class Calculator
    {
        private double A { get; }
        private double B { get; }
        private char Operation { get; }

        public Calculator(double a, double b, char operation)
        {
            A = a;
            B = b;
            Operation = operation;
        }

        public double Calculate()
        {
            if (double.IsNaN(A) || double.IsNaN(B))
                throw new ArgumentException("Operands cannot be NaN.");
            if (double.IsInfinity(A) || double.IsInfinity(B))
                throw new ArgumentException("Operands cannot be Infinity.");

            checked
            {
                return Operation switch
                {
                    '+' => A + B,
                    '-' => A - B,
                    '*' => A * B,
                    '/' => B != 0 ? A / B : throw new DivideByZeroException("Cannot divide by zero."),
                    _ => throw new InvalidOperationException($"Invalid operation: {Operation}")
                };
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var testCases = new (double, double, char)[]
            {
                (10, 5, '+'),
                (10, 5, '-'),
                (10, 5, '*'),
                (10, 5, '/'),
                (10, 0, '/'),
                (double.NaN, 5, '+'),
                (5, double.PositiveInfinity, '*'),
                (1e308, 1e308, '+'),
                (5, 5, '%')
            };

            foreach (var (a, b, op) in testCases)
            {
                var calc = new Calculator(a, b, op);
                try
                {
                    Console.WriteLine($"{a} {op} {b} = {calc.Calculate():F2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error performing {a} {op} {b}: {ex.Message}");
                }
            }
        }
    }
}