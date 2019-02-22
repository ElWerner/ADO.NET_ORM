namespace DAL.Migrations
{
    using DAL.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Context.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var items = new List<Item>
            {
                new Item
                {
                    Description = "56'' Blue Freen",
                    Price = 3.5m
                },
                new Item
                {
                    Description = "Spline End (Xtra Large)",
                    Price = 0.2m
                },
                new Item
                {
                    Description = "3'' Red Freen",
                    Price = 12m
                }
            };

            context.Items.AddOrUpdate(item => item.Description, items.ToArray());
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer
                {
                    Name = "Foo, Inc",
                    Address = "23 Main St., Thorpleburg",
                    City = "Thorpleburg",
                    State = "TX"
                },
                new Customer
                {
                    Name = "Freens R Us",
                    Address = "1600 Pennsylvania Avenue",
                    City = "Washington",
                    State = "DC"
                }
            };

            context.Customers.AddOrUpdate(customer => customer.Name, customers.ToArray());
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order
                {
                    Date = new DateTime(2018, 12, 5),
                    CustomerId = context.Customers.First(i => ("Foo, Inc").Equals(i.Name)).Id
                },
                new Order
                {
                    Date = new DateTime(2018, 12, 4),
                    CustomerId = context.Customers.First(i => ("Freens R Us").Equals(i.Name)).Id
                }
            };

            context.Orders.AddOrUpdate(order => order.Date, orders.ToArray());
            context.SaveChanges();

            var orderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    OrderId = context.Orders.First(o => o.Date == new DateTime(2018, 12, 5)).Id,
                    ItemId = context.Items.First(i => ("56'' Blue Freen").Equals(i.Description)).Id
                },
                new OrderItem
                {
                    OrderId = context.Orders.First(o => o.Date == new DateTime(2018, 12, 5)).Id,
                    ItemId = context.Items.First(i => ("Spline End (Xtra Large)").Equals(i.Description)).Id
                },
                new OrderItem
                {
                    OrderId = context.Orders.First(o => o.Date == new DateTime(2018, 12, 5)).Id,
                    ItemId = context.Items.First(i => ("3'' Red Freen").Equals(i.Description)).Id
                },
                new OrderItem
                {
                    OrderId = context.Orders.First(o => o.Date == new DateTime(2018, 12, 4)).Id,
                    ItemId = context.Items.First(i => ("56'' Blue Freen").Equals(i.Description)).Id
                },
                new OrderItem
                {
                    OrderId = context.Orders.First(o => o.Date == new DateTime(2018, 12, 4)).Id,
                    ItemId = context.Items.First(i => i.Description == "3'' Red Freen").Id
                }
            };

            context.OrderItems.AddOrUpdate(orderItems.ToArray());
            context.SaveChanges();
        }
    }
}
