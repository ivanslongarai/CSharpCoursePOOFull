using System;

namespace Deleg;
delegate double SumOperation(double n1, double n2);
delegate double SquareOperation(double n);

class Program
{
    static void Main(string[] args)
    {
        SumOperation sumOperation = Sum;
        SquareOperation squareOperation = Square;

        double sumResult = sumOperation.Invoke(10, 12);
        double squareResult = squareOperation(10);

        Console.WriteLine(sumResult);
        Console.WriteLine(squareResult);
    }

    static double Sum(double x, double y) => x + y;
    static double Square(double x) => x * x;
}
