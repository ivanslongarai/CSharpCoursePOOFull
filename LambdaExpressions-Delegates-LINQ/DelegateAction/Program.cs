using System.Globalization;
using System;
using DelegAction.Entities;


namespace DelegAction;

/*
Action(System)
A void method that receive zero ou more arguments
public delegate void Action();
public delegate void Action<in T>(T obj);
public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);
(16 overload methods)
*/

class Program
{
    static void Main(string[] args)
    {

        List<Product> list = new List<Product>();

        list.Add(new Product("TV", 2100.0));
        list.Add(new Product("Mouse", 50.0));
        list.Add(new Product("SmartPhone", 1100.0));
        list.Add(new Product("Game Console", 1500.0));
        list.Add(new Product("HD Case", 80.9));

        Console.WriteLine("------------------ Example 01");
        list.ForEach(UpdatePrice);
        list.ForEach(x => Console.WriteLine(x.Price.ToString("F2", CultureInfo.InvariantCulture)));

        Console.WriteLine("------------------ Example 02");
        Action<Product> actProduct = UpdatePrice;
        list.ForEach(actProduct);
        list.ForEach(x => Console.WriteLine(x.Price.ToString("F2", CultureInfo.InvariantCulture)));

        Console.WriteLine("------------------ Example 03");
        Action<Product> actProductLambda = p => { p.Price += p.Price * 0.1; };
        list.ForEach(actProductLambda);
        list.ForEach(x => Console.WriteLine(x.Price.ToString("F2", CultureInfo.InvariantCulture)));

        Console.WriteLine("------------------ Example 04");
        list.ForEach(p => { p.Price += p.Price * 0.1; });
        list.ForEach(x => Console.WriteLine(x.Price.ToString("F2", CultureInfo.InvariantCulture)));

    }

    static void UpdatePrice(Product p)
    {
        p.Price += p.Price * 0.1;
    }

}

