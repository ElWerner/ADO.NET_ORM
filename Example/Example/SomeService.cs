using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Entities;
namespace Example
{
    public class SomeService
    {
        public void DoSmth()
        {
            using (var context = new AppDbContext())
            {
                var items = context.Items.ToList();
                var orders = context.Orders.ToList();

                PrintItems(items);

                Console.WriteLine();

                PrintOrders(orders);
            }

            Console.ReadLine();
        }

        private void PrintItems(List<Item> items)
        {
            Console.WriteLine($"Items number: {items.Count}");

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Description} - {item.Price}");
            }
        }

        private void PrintOrders(List<Order> orders)
        {
            Console.WriteLine($"Orders number: {orders.Count}");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order {order.Id} - {order.Date}");
                Console.WriteLine($"Customer: {order.Customer.Name}");

                using (var context = new AppDbContext())
                {
                    var items = context.Items.Where(oi => oi.OrderItems.Any(o => o.OrderId == order.Id)).ToList();

                    PrintItems(items);
                }

                Console.WriteLine("------------------------------------");
            }
        }
    }
}