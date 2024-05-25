using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public static class ProductManager
{
    // Add a new product to the database
    public static void AddProduct()
    {
        Console.WriteLine("Enter product name:");
        string productName = Console.ReadLine();
        Console.WriteLine("Enter CategoryID:");
        int category = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var product = new Product
            {
                ProductName = productName,
                CategoryID = category
            };
            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }
    }

    // Delete a product from the database
    public static void DeleteProduct()
    {
        Console.WriteLine("Enter product ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }

    // Update a product in the database
    public static void UpdateProduct()
    {
        Console.WriteLine("Enter product ID:");
        int id = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                Console.WriteLine("Enter new product name:");
                product.ProductName = Console.ReadLine();
                Console.WriteLine("Enter new product quantity:");
                product.CategoryID = Convert.ToInt32(Console.ReadLine());

                context.SaveChanges();
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }
    }

    public static void ShowProductList()
    {
        Console.Clear();
        Console.WriteLine("Products List:");
        using (var context = new ShoppingDbContext())
        {
            var products = context.Products
            .Include(p => p.ProductDetails)
                .ThenInclude(d => d.Color)
            .Include(p => p.ProductDetails)
                .ThenInclude(d => d.Size)
            .ToList();

            foreach (var product in products)
            {
            Console.WriteLine($"Product Name: {product.ProductName}");
            foreach (var detail in product.ProductDetails)
            {
                Console.WriteLine($"  Color: {detail.Color.ColorName}, Size: {detail.Size.SizeName}, Quantity: {detail.Quantity}, Price: {detail.Price}");
            }
            }
        }
    }

    public static void SearchProduct()
    {

        Console.Clear();
        Menu.SubMenu_SearchProduct();
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                SearchProductByName();
                break;
            case 2:
                SearchProductByCategory();
                break;
            case 3:
                SearchProductByPriceRank();
                break;
            case 0:
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    public static void SearchProductByName()
    {
        Console.WriteLine("Enter product name:");
        string name = Console.ReadLine();

        using (var context = new ShoppingDbContext())
        {
            var products = context.Products
                .Where(p => p.ProductName.Contains(name))
                .ToList();

            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}, Product Name: {product.ProductName}");
                }
            }
            else
            {
                Console.WriteLine("No products found!");
            }
        }
    }

    public static void SearchProductByCategory()
    {
        Console.WriteLine("Enter category ID:");
        int categoryID = Convert.ToInt32(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var products = context.Products
                .Where(p => p.CategoryID == categoryID)
                .ToList();

            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}, Product Name: {product.ProductName}");
                }
            }
            else
            {
                Console.WriteLine("No products found!");
            }
        }
    }

    public static void SearchProductByPriceRank()
    {
        Console.WriteLine("Enter minimum price:");
        decimal minPrice = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter maximum price:");
        decimal maxPrice = Convert.ToDecimal(Console.ReadLine());

        using (var context = new ShoppingDbContext())
        {
            var products = context.Products
                .Include(p => p.ProductDetails)
                    .ThenInclude(d => d.Color)
                .Include(p => p.ProductDetails)
                    .ThenInclude(d => d.Size)
                .Where(p => p.ProductDetails.Any(d => d.Price >= minPrice && d.Price <= maxPrice))
                .ToList();

            if (products.Count > 0)
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"Product ID: {product.ProductID}, Product Name: {product.ProductName}");
                    foreach (var detail in product.ProductDetails)
                    {
                        Console.WriteLine($"  Color: {detail.Color.ColorName}, Size: {detail.Size.SizeName}, Quantity: {detail.Quantity}, Price: {detail.Price}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No products found!");
            }
        }
    }
}