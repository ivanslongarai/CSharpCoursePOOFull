using Challenge.Entities.Enums;
using System.Text;
using System.Globalization;

namespace Challenge.Entities;

public class Order : Entity
{
    private readonly IList<OrderItem> _items = new List<OrderItem>();
    public Order(EOrderStatus status, Customer customer)
    {
        Moment = DateTime.UtcNow;
        Status = status;
        Customer = customer;
    }

    public DateTime Moment { get; private set; }
    public EOrderStatus Status { get; private set; }
    public Customer Customer { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

    public void AddItem(OrderItem item)
    {
        _items.Add(item);
    }

    public double Total()
    {
        double total = 0;
        foreach (var item in _items)
            total += item.SubTotal();
        return total;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
        sb.AppendLine($"Order moment: {Status.ToString()}");
        sb.AppendLine($"Customer: {Customer.ToString()}");
        sb.AppendLine("Order Items:");
        foreach (var item in Items)
            sb.AppendLine(item.ToString());
        sb.Append($"Total Price: {Total().ToString("F2", CultureInfo.InvariantCulture)}");
        return sb.ToString();
    }

}