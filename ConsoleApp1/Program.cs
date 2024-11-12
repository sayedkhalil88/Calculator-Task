using System;

namespace ConsoleApp1
{
    public interface Operation
    {
        public double calculate(double x, double y);
    }
    public class Sum : Operation
    {
        public double calculate(double x, double y)
        {
            return x + y;
        }
    }
    public class Subtraction : Operation
    {
        public double calculate(double x, double y)
        {
            return x - y;
        }
    }
    public class Multiplication : Operation
    {
        public double calculate(double x, double y)
        {
            return x * y;
        }
    }
    public class Division : Operation
    {
        public double calculate(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("Invalid Operation");
            return x / y;
        }
    }
    public class Calculator
    {
        private readonly Operation _perform;
        public Calculator(Operation _perform)
        {
            this._perform = _perform;
        }
        public double PerformOperation(double x, double y)
        {
            return _perform.calculate(x, y);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
           
            while (true)
            {
                Console.WriteLine("Enter first number:");
                double a = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter second number:");
                double b = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Choose operation: +, -, *, /");
                char op = Console.ReadLine()[0];

                Calculator calculator;
                switch (op)
                {
                    case '+':
                        calculator = new Calculator(new Sum());
                        break;

                    case '-':
                        calculator = new Calculator(new Subtraction());
                        break;
                    case '*':
                        calculator = new Calculator(new Multiplication());
                        break;
                    case '/':
                        calculator = new Calculator(new Division());
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        return;

                }
                try
                {
                    double result = calculator.PerformOperation(a, b);
                    Console.WriteLine($"Result = {result}");
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                }
                Console.WriteLine("If you don't want to continue press 1 : otherwise press 0 : ");
                int TryAgain = Convert.ToInt32(Console.ReadLine());
                if (TryAgain == 1)
                    continue;
                else {
                   
                    break;
                }

            }
        }
    }

}
