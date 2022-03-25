using Challenge.Entities;
using System.Globalization;

public class OrderItem : Entity
{
    public OrderItem(Product product, double quantity, double price)
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    public Product Product { get; private set; }
    public double Quantity { get; private set; }
    public double Price { get; private set; }

    public double SubTotal()
    {
        return (Quantity * Price);
    }

    public override string ToString()
    {
        return $"{Product.Name}, ${Price}, Quantity: {Quantity}, SubTotal: {SubTotal().ToString("F2", CultureInfo.InvariantCulture)}";
    }
}