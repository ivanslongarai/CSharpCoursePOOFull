using System.Globalization;

namespace DelegPredicate.Entities;

public class Product
{
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; set; }
    public double Price { get; set; }


    public override string ToString()
    {
        return $"{Name}, {Price.ToString("F2", CultureInfo.InvariantCulture)}";
    }

}