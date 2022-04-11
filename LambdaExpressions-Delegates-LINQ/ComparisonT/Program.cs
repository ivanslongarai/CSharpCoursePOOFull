using ComparisonT.Entities;

//public delegate int Comparison<in T>(T x, T y);

bool SimpleMethodReferenceParam = true;
bool MethodReferenceSetOnDelegateVariable = false;
bool LambdaExpressionSetOnDelegateVariable = false;
bool LambdaExpressionInline = false;
bool byName = false;

if (SimpleMethodReferenceParam)
{
    var list = new List<Product>();

    list.Add(new Product("TV", 2100.0));
    list.Add(new Product("SmartPhone", 1100.0));
    list.Add(new Product("Game Console", 1500.0));

    list.Sort(CompareProducts);

    list.ForEach(x =>
        Console.WriteLine(x.ToString())
    );

    static int CompareProducts(Product p1, Product p2)
    {
        return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
    }
}


if (MethodReferenceSetOnDelegateVariable)
{
    var list = new List<Product>();

    list.Add(new Product("TV", 2100.0));
    list.Add(new Product("SmartPhone", 1100.0));
    list.Add(new Product("Game Console", 1500.0));

    Comparison<Product> compare = CompareProducts;
    list.Sort(compare);

    list.ForEach(x =>
        Console.WriteLine(x.ToString())
    );

    static int CompareProducts(Product p1, Product p2)
    {
        return p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
    }
}


if (LambdaExpressionSetOnDelegateVariable)
{
    var list = new List<Product>();

    list.Add(new Product("TV", 2100.0));
    list.Add(new Product("SmartPhone", 1100.0));
    list.Add(new Product("Game Console", 1500.0));

    Comparison<Product> compare = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
    list.Sort(compare);

    list.ForEach(x =>
        Console.WriteLine(x.ToString())
    );

}

if (LambdaExpressionInline)
{
    var list = new List<Product>();

    list.Add(new Product("TV", 2100.0));
    list.Add(new Product("SmartPhone", 1100.0));
    list.Add(new Product("Game Console", 1500.0));

    if (byName)
        list.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));
    else
        list.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));

    list.ForEach(x =>
        Console.WriteLine(x.ToString())
    );

}

