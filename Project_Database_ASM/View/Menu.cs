using System;
using System.Collections.Generic;

public static class Menu
{
    public static void MainMenu()
    {
            Console.Clear();
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Customer management");
            Console.WriteLine("2. Product Management");
            Console.WriteLine("3. Order management");
            Console.WriteLine("0. Exit");
            Console.Write("Choose function: ");
    }

    public static void CustomerMenu()
    {
        Console.WriteLine("---Customer management---");
        Console.WriteLine("1. Add customer");
        Console.WriteLine("2. Delete customer");
        Console.WriteLine("3. Update customer information");
        Console.WriteLine("4. View customer list");
        Console.WriteLine("0. Back to main menu");
        Console.Write("Choose function: ");
    }

    public static void ProductMenu()
    {
        Console.WriteLine("---Product management---");
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. Delete product");
        Console.WriteLine("3. Update product information");
        Console.WriteLine("4. View product list");
        Console.WriteLine("5. Search product");
        Console.WriteLine("0. Back to main menu");
        Console.Write("Choose function: ");
    }

    public static void OrderMenu()
    {
        Console.WriteLine("---Order management---");
        Console.WriteLine("1. Add order");
        Console.WriteLine("2. Delete order");
        Console.WriteLine("3. Update order information");
        Console.WriteLine("4. View order list");
        Console.WriteLine("0. Back to main menu");
        Console.Write("Choose function: ");
    }

    public static void SubMenu_SearchProduct()
    {
        Console.WriteLine("---Search product---");
        Console.WriteLine("1. Search by product name");
        Console.WriteLine("2. Search by product category");
        Console.WriteLine("3. Search by product price rank");
        Console.WriteLine("0. Back to product management");
        Console.Write("Choose function: ");
    }
}