using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class OderManager
{
    // Add a new order to the database
    public static void AddOrder()
    {
        Console.WriteLine("Enter customer ID:");
        int customerID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter number of items:");
        int numberOfItems = Convert.ToInt32(Console.ReadLine());

        List<OrderItem> orderItems = new List<OrderItem>();

        for (int i = 0; i < numberOfItems; i++)
        {
            Console.WriteLine($"Enter productDetail ID for item {i + 1}:");
            int productDetailID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter quantity for item {i + 1}:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            using (var context = new ShoppingDbContext())
            {
                var customer = context.Customers.Find(customerID);
                var product = context.ProductDetails.Find(productDetailID);

                if (customer == null)
                {
                    Console.WriteLine("Customer not found!");
                    return;
                }

                if (product == null)
                {
                    Console.WriteLine("Product not found!");
                    return;
                }

                var orderItem = new OrderItem
                {
                    ProductDetailID = productDetailID,
                    Quantity = quantity
                };

                orderItems.Add(orderItem);
            }
        }

        using (var context = new ShoppingDbContext())
        {
            var customer = context.Customers.Find(customerID);

            if (customer == null)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            var order = new Order
            {
                CustomerID = customerID
            };

            context.Orders.Add(order);
            context.SaveChanges();
            Console.WriteLine("Order added successfully!");
        }
    }

    // Delete an order from the database
    public static void DeleteOrder()
    {
        Console.WriteLine("Enter order ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var order = context.Orders.Find(id);

            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
                Console.WriteLine("Order deleted successfully!");
            }
            else
            {
                Console.WriteLine("Order not found!");
            }
        }
    }

    // Update an order in the database
    public static void UpdateOrder()
    {
        Console.WriteLine("Enter order ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var order = context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderID == id);

            if (order != null)
            {
                Console.WriteLine("Enter new quantity:");
                int newQuantity = Convert.ToInt32(Console.ReadLine());

                foreach (var orderItem in order.OrderItems)
                {
                    orderItem.Quantity = newQuantity;
                }

                context.SaveChanges();
                Console.WriteLine("Order updated successfully!");
            }
            else
            {
                Console.WriteLine("Order not found!");
            }
        }
    }

    public static void ShowOrderList()
    {
        Console.Clear();
        Console.WriteLine("Orders List:");
        using (var context = new ShoppingDbContext())
        {
            var orders = context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .ToList();

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Customer: {order.Customer.FullName}, Product: {order.Product.ProductName}, Quantity: {order.Quantity}");
            }
        }
    }
}