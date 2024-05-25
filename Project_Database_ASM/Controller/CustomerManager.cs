using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public static class CustomerManager
{
    // Add a new customer to the database
    public static void AddCustomer()
    {

        Console.WriteLine("Enter customer full name:");
        string fullName = Console.ReadLine();
        Console.WriteLine("Enter customer email:");
        string email = Console.ReadLine();

        // Create a new instance of the ORM context with the required options
        using (var context = new ShoppingDbContext())
        {
            // Create a new customer object with the required properties
            var customer = new Customers
            {
                FullName = fullName,
                Email = email
            };
            // Add the customer to the context
            context.Customers.Add(customer);

            // Save the changes to the database
            context.SaveChanges();
            Console.WriteLine("Customer added successfully!");
        }
    }

    // Delete a customer from the database
    public static void DeleteCustomer()
    {
        Console.WriteLine("Enter customer ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            // Find the customer with the specified ID
            var customer = context.Customers.Find(id);

            // If the customer is found, remove it from the context
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
                Console.WriteLine("Customer deleted successfully!");
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }
    }

    // Update customer information in the database
    public static void UpdateCustomer()
    {
        Console.Clear();
        Console.WriteLine("Enter customer ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            // Find the customer with the specified ID
            var customer = context.Customers.Find(id);

            // If the customer is found, update its properties
            if (customer != null)
            {
                Console.WriteLine("Enter new full name:");
                customer.FullName = Console.ReadLine();
                Console.WriteLine("Enter new email:");
                customer.Email = Console.ReadLine();

                // Save the changes to the database
                context.SaveChanges();
                Console.WriteLine("Customer updated successfully!");
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }
    }

    // Display a list of all customers in the database
public static void ShowCustomerList()
{
    Console.Clear();
    Console.WriteLine("Customer List:");
    using (var context = new ShoppingDbContext())
    {
        // Retrieve customers along with their addresses using GROUP BY
        var customers = context.Customers
            .Select(customer => new 
            {
                customer.CustomerID,
                customer.FullName,
                customer.Email,
                Addresses = customer.CustomerAddresses.Select(address => new 
                {
                    address.AddressID,
                    address.AddressName
                }).ToList()
            }).ToList();

        // Display the list of customers along with their addresses
        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.CustomerID}, Full Name: {customer.FullName}, Email: {customer.Email}");
            foreach (var address in customer.Addresses)
            {
                Console.WriteLine($"Address: {address.AddressName}, Address ID: {address.AddressID}");
            }
            Console.WriteLine();
        }
    }
}

}