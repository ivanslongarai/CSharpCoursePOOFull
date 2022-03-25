using ProjEnum.Entities;
using ProjEnum.Entities.Enums;
using System;

namespace ProjEnum
{
    class CourseEnumAndComposition
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine($"1 - {order}");

            string enumToString = OrderStatus.PendingPayment.ToString();
            Console.WriteLine($"2 - {enumToString}");

            OrderStatus stringToEnum = Enum.Parse<OrderStatus>("Delivered");
            Console.WriteLine($"3 - {stringToEnum}");

        }
    }
}
