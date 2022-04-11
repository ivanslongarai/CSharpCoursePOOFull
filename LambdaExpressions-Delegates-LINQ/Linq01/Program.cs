using System;
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

namespace Linq01;

class Program
{
    static void Main(string[] args)
    {
        // Specify the data source
        int[] numbers = new int[] { 2, 3, 4, 5 };

        // Define the query expression
        var evenNumbers = numbers
            .Where(x => x % 2 == 0)        // getting even numbers
            .Select(x => x * 10).ToList(); // Multiplaying by 10 each number

        // Exec query
        evenNumbers.ForEach(x => Console.WriteLine(x));
    }
}
