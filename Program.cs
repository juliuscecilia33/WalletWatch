using System;

class Program
{
    static void Main(string[] args)
    {
        BudgetTracker tracker = new BudgetTracker();

        while (true)
        {
            Console.WriteLine("\nBudget Tracker");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. View Transactions");
            Console.WriteLine("3. Delete Transaction");
            Console.WriteLine("4. View Budget Summary");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTransaction(tracker);
                    break;
                case "2":
                    tracker.ViewTransactions();
                    break;
                case "3":
                    DeleteTransaction(tracker);
                    break;
                case "4":
                    tracker.ViewSummary();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void AddTransaction(BudgetTracker tracker)
    {
        Console.Write("Enter date (yyyy-mm-dd): ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Console.Write("Is this income? (y/n): ");
        bool isIncome = Console.ReadLine().ToLower() == "y";

        Transaction transaction = new Transaction(date, description, amount, isIncome);
        tracker.AddTransaction(transaction);
    }

    static void DeleteTransaction(BudgetTracker tracker)
    {
        tracker.ViewTransactions();
        Console.Write("Enter the number of the transaction to delete: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        tracker.DeleteTransaction(index);
    }
}
