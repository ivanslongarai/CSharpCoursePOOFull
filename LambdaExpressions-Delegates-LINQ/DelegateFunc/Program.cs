using System;
using DelegFunc.Entities;
using System.Linq; // Language Integrated Query

namespace DelegFunc;

/*
Func(System)
A TResult method that receive zero ou more arguments and returns a value
public delegate TResult Func();
public delegate TResult Func<in T>(T obj);
public delegate TResult Func<in T1, in T2>(T1 arg1, T2 arg2);
public delegate TResult Func<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);
(16 overload methods)
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("------------------ Example 01");
        var list1 = GetList();
        var list01 = list1.Select(UperName).ToList();
        list01.ForEach(x => Console.WriteLine(x));

        Console.WriteLine("------------------ Example 02");
        var list2 = GetList();
        Func<Product, string> func = UperName;
        var list02 = list2.Select(func).ToList();
        list02.ForEach(x => Console.WriteLine(x));

        Console.WriteLine("------------------ Example 03");
        var list3 = GetList();
        Func<Product, string> funcLambda = p => p.Name.ToUpper();
        var list03 = list3.Select(funcLambda).ToList();
        list03.ForEach(x => Console.WriteLine(x));

        Console.WriteLine("------------------ Example 04");
        var list4 = GetList();
        var list04 = list4.Select(p => p.Name.ToUpper()).ToList();
        list04.ForEach(x => Console.WriteLine(x));

    }

    static string UperName(Product p) => p.Name.ToUpper();

    static List<Product> GetList()
    {
        List<Product> list = new List<Product>();
        list.Add(new Product("TV", 2100.0));
        list.Add(new Product("Mouse", 50.0));
        list.Add(new Product("SmartPhone", 1100.0));
        list.Add(new Product("Game Console", 1500.0));
        list.Add(new Product("HD Case", 80.9));
        return list;
    }

}

