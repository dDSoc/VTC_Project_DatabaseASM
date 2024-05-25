using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public static class MenuController
{
    //Main menu controller
    public static void MainMenuController()
    {
        Menu.MainMenu();
        while (true)
        {
            Menu.MainMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CustomerManagementMenu();
                    break;
                case "2":
                    ProductManagementMenu();
                    break;
                case "3":
                    OrderManagementMenu();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Chức năng không tồn tại");
                    Console.ReadKey();
                    break;
            }
        }
    }

    //Customer management menu controller
    public static void CustomerManagementMenu()
    {
        while(true)
        {
            Menu.CustomerMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CustomerManager.AddCustomer();
                    break;
                case "2":
                    CustomerManager.DeleteCustomer();
                    break;
                case "3":
                    CustomerManager.UpdateCustomer();
                    break;
                case "4":
                    CustomerManager.ShowCustomerList();
                    break;
                case "0":
                    MainMenuController();
                    break;
                default:
                    Console.WriteLine("Chức năng không tồn tại");
                    Console.ReadKey();
                    break;
            }
        }
    }

    //Product management menu controller
    public static void ProductManagementMenu()
    {
        while(true)
        {
            Menu.ProductMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ProductManager.AddProduct();
                    break;
                case "2":
                    ProductManager.DeleteProduct();
                    break;
                case "3":
                    ProductManager.UpdateProduct();
                    break;
                case "4":
                    ProductManager.ShowProductList();
                    break;
                case "5":
                    ProductManager.SearchProduct();
                    break;
                case "0":
                    MainMenuController();
                    break;
                default:
                    Console.WriteLine("Chức năng không tồn tại");
                    Console.ReadKey();
                    break;
            }
        }
    }

    //Order management menu controller
    public static void OrderManagementMenu()
    {
        while(true)
        {
            Menu.OrderMenu();

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    OderManager.AddOrder();
                    break;
                case "2":
                    OderManager.DeleteOrder();
                    break;
                case "3":
                    OderManager.UpdateOrder();
                    break;
                case "4":
                    OderManager.ShowOrderList();
                    break;
                case "0":
                    MainMenuController();
                    break;
                default:
                    Console.WriteLine("Chức năng không tồn tại");
                    Console.ReadKey();
                    break;
            }
        }
    }
}   