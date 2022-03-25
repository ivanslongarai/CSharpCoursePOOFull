using Challenge.Entities.Enums;
using Challenge.Entities;
using System.Globalization;

/*

Read the data from a Order with a number of items informed by the User
Show a Order's sumary as bellow:

Enter Customer Data:
    Name : Alex Green
    Email: alex@gmail.com
    BirthDate: (DD/MM/YYYY) 15/03/1985

Enter Order Data:
    Status: Processing
    How many items to t his order? 2
        Enter #1 Item Data:
            Product Name: TV
            Product Price: 1000.00
            Product Quantity: 1
        Enter #2 Item Data:
            Product Name: Mouse
            Product Price: 40.00
            Product Quantity: 2

ORDER SUMARY:
Order Moment: 20/04/2018 11:25:09
Order Status: Processing
Customer: Alex Green (15/03/1985) - alex@gmail.com
Order Items:
TV, $1000.00, Quantity: 1, SubTotal: $1000.00
Mouse, $40.00, Quantity: 2, SubTotal: $80.00
Total Price: $1080.00

Nota: o instante do pedido deve ser o instante do sistema: DateTime.Now
*/

Console.WriteLine("Enter Customer Data:");

// Get Customer Information
Console.Write("Name: ");
var customerName = Console.ReadLine();
Console.Write("Email: ");
var customerEmail = Console.ReadLine();
Console.Write("BirthDate: (DD/MM/YYYY) ");
var customerBirthDate = Console.ReadLine();
var customer = new Customer(customerName, customerEmail, DateTime.Parse(customerBirthDate));

// Get Order Information
Console.WriteLine("Enter Order Data:");
Console.Write("Status: ");
var orderStatus = Console.ReadLine();
var order = new Order(Enum.Parse<EOrderStatus>(orderStatus), customer);

// Get Order Items Information
Console.Write("How many items to t his order? ");
var itemsCount = Console.ReadLine();

var productName = "";
double productPrice;
double productQuantity;

// Pre load Products
var products = new List<Product>();
products.Add(new Product("TV", 100.0));
products.Add(new Product("Mouse", 100.0));

for (var i = 1; i < int.Parse(itemsCount) + 1; i++)
{
    Console.WriteLine($"Enter #{i} Item Data:");

    Console.Write("Product Name: ");
    productName = Console.ReadLine();
    Console.Write("Price: ");
    productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Console.Write("Quantity: ");
    productQuantity = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    order.AddItem(new OrderItem(
            products.FirstOrDefault(x => x.Name == productName),
            productQuantity,
            productPrice)
        );
}

Console.WriteLine("-----------------------------------------");
Console.WriteLine("ORDER SUMARY");
Console.WriteLine(order);
Console.WriteLine("-----------------------------------------");

// Tested output 
/*
-----------------------------------------
ORDER SUMARY
Order moment: 25/03/2022 16:38:24
Order moment: Processing
Customer: Alex Green(15/03/1976) - alex@gmail.com
Order Items:
TV, $1000, Quantity: 1, SubTotal: 1000.00
Mouse, $40, Quantity: 2, SubTotal: 80.00
Total Price: 1080.00
---------------------------------------- -
*/
