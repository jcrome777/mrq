using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        User currentUser = LoginSystem.Login();

        if (currentUser.accessLevel == "manager")
        {
            ShowManagerMenu();
        }
        else if (currentUser.accessLevel == "cashier")
        {
            ShowCashierMenu();
        }

        static void ShowManagerMenu()
        {
            List<Product> products = new List<Product>();
            Product methodCaller = new Product();

            string filePath = @"productslog.txt";

            Product.LoadUserDataFromFile(filePath, products);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHi, I'm your Toystore Management Network, or TOYMANN for short! I'm your trusty and reliable companion for running your own toystore!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================================================================================================\n");

            while (true)
            {
                Console.WriteLine("What would you like to do today?\n");
                Console.WriteLine("1 - Add a new product");
                Console.WriteLine("2 - Update or remove a product");
                Console.WriteLine("3 - Check a product's details");
                Console.WriteLine("4 - List all products");
                Console.WriteLine("5 - Log a sold product");
                Console.WriteLine("6 - Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nAdding a new product...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        methodCaller.newProduct(products);
                        Product.SaveUserDataToFile(filePath, products);
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nUpdating or removing a product...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        methodCaller.productUpdater(products);
                        Product.SaveUserDataToFile(filePath, products);
                        break;

                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nChecking a products details...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        methodCaller.productChecker(products);
                        break;

                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nListing all products...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("========================================================\n");
                        methodCaller.productLister(products);
                        break;

                    case 5:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nSelling a product...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        methodCaller.productSold(products);
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting program, goodbye!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have inputted an invalid choice, please try again!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        static void ShowCashierMenu()
        {
            List<Product> products = new List<Product>();
            Product methodCaller = new Product();

            string filePath = @"productslog.txt";

            Product.LoadUserDataFromFile(filePath, products);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nHi, I'm your Toystore Management Network, or TOYMANN for short! I'm your trusty and reliable companion for running your own toystore!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================================================================================================\n");

            while (true)
            {
                Console.WriteLine("What would you like to do today?\n");
                Console.WriteLine("1 - Check a product's details");
                Console.WriteLine("2 - List all products");
                Console.WriteLine("3 - Enter checkout menu");
                Console.WriteLine("4 - Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nChecking a products details...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        methodCaller.productChecker(products);
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nListing all products...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("========================================================\n");
                        methodCaller.productLister(products);
                        break;

                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nSelling a product...\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        methodCaller.checkoutMenu(products);
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Exiting program, goodbye!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have inputted an invalid choice, please try again!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }
    }
}
