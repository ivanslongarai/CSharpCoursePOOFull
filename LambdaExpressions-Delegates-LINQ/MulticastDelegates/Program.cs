using System;

namespace MulticastDeleg;
delegate void BinaryOperation(double n1, double n2);

class Program
{
    static void Main(string[] args)
    {
        BinaryOperation operation = Sum;
        operation += Max;
        Console.WriteLine("---------------- Works as the same way");
        operation.Invoke(10, 12);
        Console.WriteLine("---------------- Works as the same way");
        operation(10, 12);
    }

    static void Sum(double x, double y) => Console.WriteLine(x + y);
    static void Max(double x, double y) => Console.WriteLine(x > y ? x : y);
}
