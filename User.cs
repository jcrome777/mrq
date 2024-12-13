using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using System.Xml.Schema;
using System.Runtime.CompilerServices;

public class User
{
    public string username { get; set; }
    public string password { get; set; }
    public string accessLevel { get; set; }

    public User(string username, string password, string accessLevel)
    {
        this.username = username;
        this.password = password;
        this.accessLevel = accessLevel;
    }
}

public static class UserManager
{
    public static List<User> Users = new List<User>()
    {
        new User("Rome", "password", "cashier"),
        new User("Carlos", "admin", "manager")
    };

    public static User Login(string username, string password)
    {
        return Users.Find(user => user.username == username && user.password == password);
    }
}

public static class LoginSystem
{
    public static User Login()
    {
        string username, password;

        while (true)
        {
            Console.Clear();
            Console.Write("Enter Username: ");
            username = Console.ReadLine();

            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            User user = UserManager.Login(username, password);

            if (user != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome, {user.username} ({user.accessLevel})!");
                Console.ForegroundColor = ConsoleColor.White;
                return user;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid credentials, please try again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine(); // Pause for user to see the message
            }
        }
    }
}