using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using System.Xml.Schema;
using System.Runtime.CompilerServices;

public interface baseProduct
{
    void newProduct(List<Product> products);
    void productUpdater(List<Product> products);
    void productChecker(List<Product> products);
    void productLister(List<Product> products);
    void productSold(List<Product> products);

}
public abstract class abstractProduct : baseProduct
{
    public string name { get; set; }
    public int id { get; set; }
    public double price { get; set; }
    public int quantity { get; set; }
    public int sold { get; set; }
    public double soldtotal { get; set; }
    public List<Category> Categories { get; set; } = new List<Category>();

    public abstract void newProduct(List<Product> products);
    public abstract void checkoutMenu(List<Product> products);
    public abstract void productUpdater(List<Product> products);
    public abstract void productChecker(List<Product> products);
    public abstract void productLister(List<Product> products);
    public abstract void productSold(List<Product> products);

}
public class Product : abstractProduct
{
    private int GetValidChoice(int maxOption)
    {
        int choice;
        while (true)
        {
            try
            {
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > maxOption)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nPlease enter a number between 1 and {maxOption}.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid number.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        return choice;
    }

    public override void newProduct(List<Product> products)
    {
        bool existence;
        Product newProd = new Product();

        while (true)
        {
            try
            {
                Console.Write("Enter the product's name: ");
                newProd.name = Console.ReadLine();
                existence = products.Exists(product => product.name == newProd.name);
                if (existence)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, a product with the same name already exists in the inventory! Please enter another name.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid product name.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Enter the product's ID: ");
                newProd.id = int.Parse(Console.ReadLine());
                existence = products.Exists(product => product.id == newProd.id);
                if (existence)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, a product with the same ID already exists in the inventory! Please enter another ID.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid integer for the product ID.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Enter the product's price: P");
                newProd.price = double.Parse(Console.ReadLine());
                if (newProd.price < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, the product price cannot be negative! Please enter a valid price.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid number for the product price.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Enter the quantity of product in stock: ");
                newProd.quantity = int.Parse(Console.ReadLine());
                if (newProd.quantity < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, the product quantity cannot be negative! Please enter a valid quantity.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input. Please enter a valid integer for the product quantity.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
        }

        List<Category> ageCategories = new List<Category>
        {
            new Category("Infant", "0-12 months old"),
            new Category("Toddler", "1-3 years old"),
            new Category("Preschool", "3-5 years old"),
            new Category("Kids", "6-12 years old"),
            new Category("Teens", "13+ years old")
        };

        Console.WriteLine("Select the toy's age range:");
        for (int i = 0; i < ageCategories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {ageCategories[i].name}");
        }

        int ageChoice = GetValidChoice(ageCategories.Count);
        newProd.Categories.Add(ageCategories[ageChoice - 1]);

        List<Category> typeCategories = new List<Category>
        {
            new Category("Educational", "Toys that promote learning and skill development, focusing on subjects like math, science, and language."),
            new Category("Action Figures, Dolls, & Figurines", "Collectible or play toys representing characters, superheroes, or fictional figures."),
            new Category("Building Set", "Toys that allow children to construct models or structures using blocks, pieces, or parts."),
            new Category("Puzzles", "Toys designed to challenge problem-solving skills by fitting pieces together to form images or shapes."),
            new Category("Board Games", "Tabletop games involving strategy, luck, or teamwork, typically played with a board, cards, or dice."),
            new Category("Plushies", "Soft, stuffed toys that are cuddly and often designed to resemble animals or characters."),
            new Category("Electronic", "Toys that incorporate electronics for interactive or digital play, like robots, games, or gadgets."),
            new Category("Arts and Craft", "Supplies or kits for creative expression, such as coloring, painting, or making crafts."),
            new Category("Outdoor & Sports", "Toys designed for physical activity and play outside, including sporting goods and active toys."),
            new Category("Musical Instruments", "Toys that introduce children to music, such as mini keyboards, drums, or guitars."),
            new Category("Playsets", "Toys that recreate real-world environments (like a kitchen set or dollhouse) for imaginative play."),
            new Category("Vehicles", "Toys that include cars, trucks, trains, planes, and other forms of transport for play and exploration."),
            new Category("Game Consoles", "Electronic devices designed for video game play, often featuring interactive games for kids and adults.")
        };

        Console.WriteLine("\nSelect a Toy Type:");
        for (int i = 0; i < typeCategories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {typeCategories[i].name}");
        }

        int typeChoice = GetValidChoice(typeCategories.Count);
        newProd.Categories.Add(typeCategories[typeChoice - 1]);

        products.Add(newProd);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nNew product successfully added!\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("=========================================\n");


    }

    public override void checkoutMenu(List<Product> products)
    {
        string payMethod;
        double allTotal = 0;
        double prodTotal;
        bool exit = false;
        int quant;
        Product selectedProduct = new Product();
        List<string> items = new List<string>();

        while (!exit)
        {
                Console.Write("Enter the product ID to add to cart, type 'done' to checkout, or type 'exit' to exit menu: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "done")
                {
                    Console.WriteLine("Method of payment:\n");
                    Console.WriteLine("1 - Cash");
                    Console.WriteLine("2 - GCash");
                    Console.WriteLine("3 - Card");
                }
                else if (input.ToLower() == "exit") 
                {
                    exit = true;
                }
                else
                {
                    int prodID = int.Parse(input);

                    selectedProduct = products.Find(product => product.id == prodID);

                    if (selectedProduct == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nSorry, no product with that ID exists in the inventory! Please try again.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    Console.Write("Enter the quantity: ");
                    quant = int.Parse(Console.ReadLine());

                    if (quant > selectedProduct.quantity)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, the inputted number is higher than the currently available stock! Available quantity: " + selectedProduct.quantity);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    prodTotal = selectedProduct.price * quant;
                    allTotal += prodTotal;
                    selectedProduct.quantity -= quant;

                    Console.WriteLine($"{selectedProduct.name} added to cart. Total so far: P{allTotal}");
                }

        }
    }

    public override void productUpdater(List<Product> products)
    {
        int sq;
        int choice;
        int x;
        bool existence;
        int remove;
        bool exit = false;
        Product updater = new Product();

        while (true)
        {
            Console.Write("Enter the ID of the product you'd like to update: ");
            sq = int.Parse(Console.ReadLine());
            x = products.FindIndex(product => product.id == sq);
            if (x == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSorry, no product with that ID exists in the inventory! Please try again.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("\n=========================================\n");

        while (!exit)
        {
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1 - Update name");
            Console.WriteLine("2 - Update ID");
            Console.WriteLine("3 - Update price");
            Console.WriteLine("4 - Product restock");
            Console.WriteLine("5 - Remove product");
            Console.WriteLine("6 - Exit");
            Console.Write("\nEnter choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:

                    while (true)
                    {
                        Console.Write("\nWhat would you like to update the product name to?: ");
                        updater.name = Console.ReadLine();
                        existence = products.Exists(product => product.name == updater.name);
                        if (existence)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nSorry, a product with the same name already exists in the inventory! Please enter a valid name.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            products[x].name = updater.name;
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProduct name successfully updated!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================\n");
                    break;

                case 2:

                    while (true)
                    {
                        Console.Write("\nWhat would you like to update the product ID to?: ");
                        updater.id = int.Parse(Console.ReadLine());
                        existence = products.Exists(product => product.id == updater.id);
                        if (existence)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nSorry, a product with the same ID already exists in the inventory! Please enter a valid ID.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            products[x].id = updater.id;
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProduct ID successfully updated!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================\n");
                    break;

                case 3:

                    while (true)
                    {
                        Console.Write("\nWhat would you like to update the product's price to?: P");
                        updater.price = double.Parse(Console.ReadLine());
                        if (updater.price < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nSorry, the product price cannot be negative! Please enter a valid price.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            products[x].price = updater.price;
                            break;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProduct price successfully updated!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================\n");
                    break;

                case 4:

                            int restock;
                            while (true)
                            {
                                Console.Write("\nHow many {0}s did you restock?: ", products[x].name);
                                restock = int.Parse(Console.ReadLine());
                                if (restock < 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nSorry, the restock cannot be negative! Please enter a valid number.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    products[x].quantity = products[x].quantity + restock;
                                    break;
                                }
                            }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProduct quantity successfully updated!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================\n");
                    break;

                case 5:
                    Console.WriteLine("\nAre you sure you want to remove the product?\n");
                    Console.WriteLine("1 - Yes");
                    Console.WriteLine("2 - Cancel\n");
                    Console.Write("Enter your choice: ");
                    remove = int.Parse(Console.ReadLine());
                    if (remove == 1)
                    {
                        Console.Clear();
                        products.RemoveAll(product => product.id == sq);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nThe product has been successfully removed!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                        exit = true;
                    }
                    else if (remove == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nCancelling!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have inputted an invalid choice, please try again!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("=========================================\n");
                    }

                    break;

                case 6:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nExiting product updater!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================\n");
                    exit = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have inputted an invalid choice, please try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("=========================================\n");
                    break;
            }
        }
    }

    public void DisplayCategories()
    {
        if (Categories.Count == 0)
        {
            Console.WriteLine("No categories assigned to this product.");
        }
        else
        {
            Console.WriteLine("Categories assigned to this product:");
            foreach (var Category in Categories)
            {
                Console.WriteLine($"- {Category.name}: {Category.description}");
            }
        }
    }

    public override void productChecker(List<Product> products)
    {
        try
        {
            int sq;
            int choice;

            while (true)
            {
                Console.Write("Enter the ID of the product you'd like to check: ");

                try
                {
                    sq = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Please enter a valid integer.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                int x = products.FindIndex(product => product.id == sq);
                if (x == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, no product with that ID exists in the inventory! Please try again.\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nProduct Details:");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nName: " + products[x].name);
                    Console.WriteLine("ID: " + products[x].id);
                    Console.WriteLine("Price: P" + products[x].price);
                    Console.WriteLine("Quantity in stock: " + products[x].quantity);
                    Console.WriteLine("Total amount of {0}s sold: {1}", products[x].name, products[x].sold);
                    Console.WriteLine("Total value of sold {0}s: P{1}", products[x].name, products[x].soldtotal);
                    Console.WriteLine("\nCategories:");
                    products[x].DisplayCategories();
                    Console.WriteLine();
                    Console.WriteLine("========================================================================================================================\n");

                    while (true)
                    {
                        Console.Write("Enter 1 to continue: ");

                        try
                        {
                            choice = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid input. Please enter a valid integer.\n");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }

                        if (choice != 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nYou have inputted an invalid choice, please try again!\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nExiting product checker!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("========================================================================================================================\n");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public override void productLister(List<Product> products)
    {
        try
        {
            int choice;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Products in inventory: \n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, products[i].name);
                Console.WriteLine("\tID: " + products[i].id);
                Console.WriteLine();
            }

            Console.WriteLine("========================================================================================================================\n");

            while (true)
            {
                Console.Write("Enter 1 to continue: ");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice != 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou have inputted an invalid choice, please try again!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou have inputted an invalid choice, please try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou have inputted an invalid choice, please try again!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nExiting product lister!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================================================================================================\n");
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public override void productSold(List<Product> products)
    {
        int x;
        int sq;

        while (true)
        {
            Console.Write("Enter the ID of the product you'd like to update: ");
            sq = int.Parse(Console.ReadLine());
            x = products.FindIndex(product => product.id == sq);
            if (x == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSorry, no product with that ID exists in the inventory! Please try again.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                break;
            }
        }

        Product updater = new Product();

        while (true)
        {
            Console.Write("\nHow many {0}s did you sell?: ", products[x].name);
            updater.sold = int.Parse(Console.ReadLine());
            if (updater.sold < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSorry, you cannot sell negative products! Please enter a valid number.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (updater.sold > products[x].quantity)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSorry, you cannot sell more products than you have in your inventory! Please enter a valid number.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                products[x].sold = updater.sold;
                products[x].quantity = products[x].quantity - products[x].sold;
                products[x].soldtotal = products[x].sold * products[x].price;
                break;
            }
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nExiting sold product logger!\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("========================================================================================================================\n");
    }

    public static void SaveUserDataToFile(string filePath, List<Product> products)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var newProd in products)
            {
                writer.WriteLine($"Name: {newProd.name}");
                writer.WriteLine($"ID: {newProd.id}");
                writer.WriteLine($"Price: {newProd.price}");
                writer.WriteLine($"Quantity: {newProd.quantity}");
                writer.WriteLine($"Amount sold: {newProd.sold}");
                writer.WriteLine($"Value sold: {newProd.soldtotal}");
                writer.WriteLine();// Add an empty line to separate entries
            }
        }
    }

    public static List<Product> LoadUserDataFromFile(string filePath, List<Product> products)

    {

        using (StreamReader reader = new StreamReader(filePath))
        {

            while (!reader.EndOfStream) 
            {
                // Read data for each product
                string name = reader.ReadLine()?.Replace("Name: ", "") ?? "";
                int id = int.Parse(reader.ReadLine()?.Replace("ID: ", "") ?? "0");
                double price = double.Parse(reader.ReadLine()?.Replace("Price: ", "") ?? "0");
                int quantity = int.Parse(reader.ReadLine()?.Replace("Quantity: ", "") ?? "0");
                int sold = int.Parse(reader.ReadLine()?.Replace("Amount sold: ", "") ?? "0");
                double soldtotal = double.Parse(reader.ReadLine()?.Replace("Value sold: ", "") ?? "0");


                // Create Product object and add to the list
                Product newProd = new Product();

                newProd.name = name;
                newProd.id = id;
                newProd.price = price;
                newProd.quantity = quantity;
                newProd.sold = sold;
                newProd.soldtotal = soldtotal;

                products.Add(newProd);

                // Skip the empty line (separator)
                reader.ReadLine();
            }
        }

        return products;
    }

}