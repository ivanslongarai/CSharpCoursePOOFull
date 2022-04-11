using System.Globalization;
using System;
using Linq02.Entities;
using System.Linq; // Language Integrated Query

/*
    LINQ Operations
    • Filtering: Where, OfType
    • Sorting: OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse
    • Set: Distinct, Except, Intersect, Union
    • Quantification: All, Any, Contains
    • Projection: Select, SelectMany
    • Partition: Skip, Take
    • Join: Join, GroupJoin
    • Grouping: GroupBy
    • Generational: Empty
    • Equality: SequenceEquals
    • Element: ElementAt, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault
    • Conversions: AsEnumerable, AsQueryable
    • Concatenation: Concat
    • Aggregation: Aggregate, Average, Count, LongCount, Max, Min, Sum
*/

namespace Linq02;

class Program
{
    static void Main(string[] args)
    {
        var category01 = new Category { Id = 1, Name = "Excelent", Tier = 1 };
        var category02 = new Category { Id = 2, Name = "Good", Tier = 2 };
        var category03 = new Category { Id = 3, Name = "Regular", Tier = 3 };

        List<Product> products = new List<Product>
        {
            new Product{ Id = 1, Name = "Computer", Price = 800.0, Category = category01},
            new Product{ Id = 2, Name = "TV", Price = 1500.0, Category = category01},
            new Product{ Id = 3, Name = "Notebook", Price = 1800.0, Category = category01},
            new Product{ Id = 4, Name = "Macbook", Price = 2100.0, Category = category01},
            new Product{ Id = 5, Name = "Level", Price = 80.0, Category = category02},
            new Product{ Id = 6, Name = "Saw", Price = 110.0, Category = category02},
            new Product{ Id = 7, Name = "Tablet", Price = 800.0, Category = category03},
            new Product{ Id = 8, Name = "Guitar", Price = 1600.0, Category = category02},
            new Product{ Id = 9, Name = "Monitor", Price = 2300.0, Category = category03},
            new Product{ Id = 10, Name = "Bed", Price = 1900.0, Category = category02},
            new Product{ Id = 11, Name = "Pen", Price = 10.0, Category = category03}
        };

        Console.WriteLine("---- All tier 1 products with price lower than 900.0");
        var result01 = products.Where(x => x.Category?.Tier == 1 && x.Price < 900.0).ToList();
        result01.ForEach(x => Console.WriteLine(x.ToString()));
        Console.WriteLine("");

        Console.WriteLine("---- Product names with category as Good");
        var result02 = products.Where(x => x.Category?.Name == "Good").Select(x => x.Name).ToList();
        result02.ForEach(x => Console.WriteLine(x?.ToString()));
        Console.WriteLine("");

        Console.WriteLine("---- Products with name starting with 'T' returning an anonymous object");
        var result03 = products.Where(x => x.Name!.StartsWith("T"))
            .Select(x => new { x.Name, x.Price, CategoryName = x.Category!.Name }).ToList();
        result03.ForEach(x => Console.WriteLine(x.ToString()));
        Console.WriteLine("");

        Console.WriteLine("---- All Tier 1 category ordered by Price");
        var result04 = products.Where(x => x.Category!.Tier == 1).OrderByDescending(x => x.Price).ToList();
        result04.ForEach(x => Console.WriteLine(x.ToString()));
        Console.WriteLine("");

        Console.WriteLine("---- Skip the first two and take the two others");
        var result05 = result04.Skip(2).Take(2).ToList();
        result05.ForEach(x => Console.WriteLine(x.ToString()));
        Console.WriteLine("");

        Console.WriteLine("---- Getting the first one");
        var result06 = result05.First();
        Console.WriteLine(result06.ToString());
        Console.WriteLine("");

        Console.WriteLine("---- Getting a null result from First|Last!Single");
        var result07 = products.Where(x => x.Price > 10000.0).FirstOrDefault();
        Console.WriteLine(result07 != null ? result07.ToString() : "Null object");
        Console.WriteLine("");

        Console.WriteLine("---- Getting max price");
        var result08 = products.Max(x => x.Price);
        Console.WriteLine(result08.ToString());
        Console.WriteLine("");

        Console.WriteLine("---- Getting min price");
        var result09 = products.Min(x => x.Price);
        Console.WriteLine(result09.ToString());
        Console.WriteLine("");

        Console.WriteLine("---- Getting sum price");
        var result10 = products
        .Where(x => x.Category!.Id == 1)
        .Sum(x => x.Price);
        Console.WriteLine(result10.ToString());
        Console.WriteLine("");

        Console.WriteLine("---- Getting avarage price with items");
        var result11 = products.Where(x => x.Category!.Tier == 3)
            .Select(x => x.Price)
            .Average();
        Console.WriteLine(result11.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("");

        Console.WriteLine("---- Getting avarage price without items");
        var result12 = products.Where(x => x.Category!.Tier == 5)
            .Select(x => x.Price)
            .DefaultIfEmpty(0.0)
            .Average();
        Console.WriteLine(result12.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("");

        Console.WriteLine("---- Category 1 aggregate sum with items (Select/Aggregate Map/Reduce)");
        var result13 = products.Where(x => x.Category!.Id == 1)
            .Select(x => x.Price)
            .Aggregate((x, y) => x + y);
        Console.WriteLine(result13.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("");

        Console.WriteLine("---- Category 1 aggregate sum without items (Select/Aggregate Map/Reduce)");
        var result14 = products.Where(x => x.Category!.Id == 5)
            .Select(x => x.Price)
            .Aggregate(0.0, (x, y) => x + y);
        Console.WriteLine(result14.ToString("F2", CultureInfo.InvariantCulture));
        Console.WriteLine("");

        Console.WriteLine("---- Group by Category");
        var result15 = products.GroupBy(x => x.Category);
        foreach (IGrouping<Category?, Product> group in result15)
        {
            Console.WriteLine($"Category: {group.Key!.Name} :");
            foreach (Product product in group)
                Console.WriteLine($"    Product: {product.Name}");
            Console.WriteLine();
        }
        Console.WriteLine("");

        Console.WriteLine("---- Linq with similar SQL notation - All tier 1 products with price lower than 900.0");
        var result16 =
            from x in products
            where x.Category?.Tier == 1 && x.Price < 900.0
            select x;
        result01.ForEach(x => Console.WriteLine(x.ToString()));
        Console.WriteLine("");

    }
}
