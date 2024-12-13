using System;
using System.Collections.Generic;

public class transaction
{
	public int refnumber { get; set; };
	public double allTotal { get; set; }
	public double custPaid { get; set; }
	public double change { get; set; }
	public string paymethod { get; set; }
	public List<transacItem> items { get; set; } = new List<transacItem>();
	public DateTime transacDate { get; set; }

    // Method to add an item to the transaction
    public void addItem(Product product, int quantity, double price)
    {
        Items.Add(new TransactionItem
        {
            ProductName = product.Name,
            Quantity = quantity,
            PricePerItem = price,
            TotalPrice = price * quantity
        });
        TotalAmount += price * quantity;
    }

    // Method to finalize the payment and calculate change
    public void ProcessPayment(double payment)
    {
        AmountPaid = payment;
        if (AmountPaid >= TotalAmount)
        {
            Change = AmountPaid - TotalAmount;
        }
        else
        {
            Change = 0;
        }
    }

    // Method to display the transaction summary
    public void DisplayTransactionSummary()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("--- Transaction Summary ---");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Transaction ID: {TransactionId}");
        Console.WriteLine($"Date: {TransactionDate}");
        Console.WriteLine("Items Purchased:");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.ProductName} x{item.Quantity} - P{item.TotalPrice}");
        }
        Console.WriteLine($"Total Amount: P{TotalAmount}");
        Console.WriteLine($"Amount Paid: P{AmountPaid}");
        Console.WriteLine($"Change: P{Change}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

}

public class transacItem
{
	public string prodName { get; set; }
	public int quant { get; set; }
	public double price { get; set; }
	public double prodTotal { get; set; }
}