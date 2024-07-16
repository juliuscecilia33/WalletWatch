using System;
using System.Collections.Generic;
using System.Linq;

public class BudgetTracker
{
    private List<Transaction> transactions = new List<Transaction>();

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public void DeleteTransaction(int index)
    {
        if (index >= 0 && index < transactions.Count)
        {
            transactions.RemoveAt(index);
        }
    }

    public void ViewTransactions()
    {
        for (int i = 0; i < transactions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transactions[i]}");
        }
    }

    public void ViewSummary()
    {
        decimal totalIncome = transactions.Where(t => t.IsIncome).Sum(t => t.Amount);
        decimal totalExpenses = transactions.Where(t => !t.IsIncome).Sum(t => t.Amount);
        decimal netBalance = totalIncome - totalExpenses;

        Console.WriteLine($"Total Income: {totalIncome:C}");
        Console.WriteLine($"Total Expenses: {totalExpenses:C}");
        Console.WriteLine($"Net Balance: {netBalance:C}");
    }
}
