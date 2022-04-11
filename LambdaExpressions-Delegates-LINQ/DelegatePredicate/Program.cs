using System;
using DelegPredicate.Entities;

//public delegate bool Predicate<in T>(T obj);

namespace DelegPredicate;

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

        Console.WriteLine("------------------ Using lambda expression");
        list.RemoveAll(x => x.Price >= 100.0);
        list.ForEach(x => Console.WriteLine(x.Name));

        Console.WriteLine("------------------ Using predicate (delegate)");
        list.RemoveAll(TestProduct);
        list.ForEach(x => Console.WriteLine(x.Name));
    }

    public static bool TestProduct(Product p) => p.Price >= 80.0;

}
