using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// -------------------- Program Class --------------------
class Program
{
    static string usersFile = "users.json";
    static string chickensFile = "chickens.json";
    static string salesFile = "sales.json";

    static void Main()
    {
        // --- Load data ---
        List<User> users = LoadData<User>(usersFile);
        List<Chicken> flock = LoadData<Chicken>(chickensFile);
        List<Sale> sales = LoadData<Sale>(salesFile);

        User currentUser = null;

        // --- Sign Up / Sign In ---
        bool loggedIn = false;
        while (!loggedIn)
        {
            Console.Clear();
            Console.WriteLine("=== Welcome to Poultry Farm Management System ===\n");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Sign In");
            Console.Write("Enter your choice: ");
            string loginChoice = Console.ReadLine();

            switch (loginChoice)
            {
                case "1":
                    Console.Write("Enter new username: ");
                    string newUsername = Console.ReadLine();
                    Console.Write("Enter new password: ");
                    string newPassword = Console.ReadLine();

                    users.Add(new User(newUsername, newPassword));
                    SaveData(usersFile, users);
                    Console.WriteLine("Account created successfully! Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    User user = users.Find(u => u.Username == username && u.Password == password);
                    if (user != null)
                    {
                        currentUser = user;
                        loggedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Press Enter to try again...");
                        Console.ReadLine();
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }

        // --- Poultry Farm Management System ---
        List<HealthRecord> healthRecords = new List<HealthRecord>();
        List<Customer> customers = new List<Customer>();
        FeedInventory feedInventory = new FeedInventory("Starter Feed", 100, 25);
        FarmReport report = new FarmReport();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Poultry Farm Management System ===");
            Console.WriteLine("1. Add New Chicken");
            Console.WriteLine("2. Record Egg Production");
            Console.WriteLine("3. Log Health Issue");
            Console.WriteLine("4. Feed Chickens");
            Console.WriteLine("5. Record Sale");
            Console.WriteLine("6. View Reports");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddNewChicken(flock);
                    SaveData(chickensFile, flock);
                    break;
                case "2":
                    RecordEggProduction(flock);
                    SaveData(chickensFile, flock);
                    break;
                case "3":
                    LogHealthIssue(healthRecords);
                    break;
                case "4":
                    FeedChickens(feedInventory);
                    break;
                case "5":
                    RecordSale(sales, customers);
                    SaveData(salesFile, sales);
                    break;
                case "6":
                    ViewReports(sales, healthRecords, feedInventory, report);
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }

        Console.WriteLine("Exiting... Goodbye!");
    }

    // -------------------- Methods --------------------
    static void AddNewChicken(List<Chicken> flock)
    {
        Console.Write("Enter Chicken ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID. Must be a number.");
            return;
        }

        Console.Write("Enter Chicken Age (in days): ");
        if (!int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine("Invalid age. Must be a number.");
            return;
        }

        Console.Write("Enter Chicken Type (e.g. Layer, Broiler): ");
        string type = Console.ReadLine();

        Chicken chicken = new Chicken(id, age, type);
        flock.Add(chicken);

        Console.WriteLine("Chicken added successfully!");
    }

    static void RecordEggProduction(List<Chicken> flock)
    {
        if (flock.Count == 0)
        {
            Console.WriteLine("No chickens found.");
            return;
        }

        Console.Write("Enter Chicken ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Chicken chicken = flock.Find(c => c.Id == id);
        if (chicken == null)
        {
            Console.WriteLine("Chicken not found.");
            return;
        }

        Console.Write("Enter number of eggs: ");
        if (!int.TryParse(Console.ReadLine(), out int eggs))
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        chicken.AddEggProductionRecord(new EggProduction(DateTime.Now, eggs));
        Console.WriteLine("Egg production recorded.");
    }

    static void LogHealthIssue(List<HealthRecord> healthRecords)
    {
        Console.Write("Enter symptoms: ");
        string symptoms = Console.ReadLine();

        Console.Write("Enter treatment: ");
        string treatment = Console.ReadLine();

        healthRecords.Add(new HealthRecord(DateTime.Now, symptoms, treatment));
        Console.WriteLine("Health record logged.");
    }

    static void FeedChickens(FeedInventory inventory)
    {
        Console.Write("Enter amount of feed to consume (kg): ");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Invalid input. Must be a number.");
            return;
        }

        inventory.ConsumeFeed(amount);
        Console.WriteLine("Feed consumed.");

        if (inventory.CheckReorder())
            Console.WriteLine("Warning: Feed is below reorder level!");
    }

    static void RecordSale(List<Sale> sales, List<Customer> customers)
    {
        Console.Write("Enter customer name: ");
        string name = Console.ReadLine();

        Console.Write("Enter contact info: ");
        string contact = Console.ReadLine();

        Customer customer = customers.Find(c => c.GetCustomerInfo().Contains(name));
        if (customer == null)
        {
            customer = new Customer(name, contact);
            customers.Add(customer);
        }

        Console.Write("Enter product type (e.g. Eggs, Chicken): ");
        string product = Console.ReadLine();

        Console.Write("Enter quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int qty))
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }

        Sale sale = new Sale(product, qty, DateTime.Now, customer);
        sales.Add(sale);
        customer.AddPurchase(sale);

        Console.WriteLine("Sale recorded successfully!");
    }

    static void ViewReports(List<Sale> sales, List<HealthRecord> healthRecords, FeedInventory feedInventory, FarmReport report)
    {
        Console.WriteLine("1. Sales Report");
        Console.WriteLine("2. Health Report");
        Console.WriteLine("3. Feed Report");
        Console.Write("Choose report: ");
        string option = Console.ReadLine();
        Console.WriteLine();

        switch (option)
        {
            case "1":
                Console.WriteLine(report.GenerateSalesReport(sales));
                break;
            case "2":
                Console.WriteLine(report.GenerateHealthReport(healthRecords));
                break;
            case "3":
                Console.WriteLine(report.GenerateFeedUsageReport(feedInventory));
                break;
            default:
                Console.WriteLine("Invalid report choice.");
                break;
        }
    }

    // -------------------- File Persistence --------------------
    static void SaveData<T>(string filename, List<T> data)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.Preserve
        };
        string json = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filename, json);
    }

    static List<T> LoadData<T>(string filename)
    {
        if (!File.Exists(filename))
            return new List<T>();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        string json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<List<T>>(json, options) ?? new List<T>();
    }
}
