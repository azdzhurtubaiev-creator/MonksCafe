namespace MonksCafe;
using System.Globalization;
public static class Ui
{
    public static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Monk's Cafe");
        Console.WriteLine("-----------------------");
        Console.WriteLine("1. Add Item");
        Console.WriteLine("2. Remove Item");
        Console.WriteLine("3. Add Tip");
        Console.WriteLine("4. Display Bill");
        Console.WriteLine("5. Clear All");
        Console.WriteLine("6. Save to file");
        Console.WriteLine("7. Load from file");
        Console.WriteLine("0. Exit");
        Console.WriteLine();
    }

    public static string AskString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    public static void AddItem(BillService bill)
    {
        if (bill.Items.Count >= BillService.MaxItems)
        {
            Console.WriteLine($"Cannot add item: the bill is full ({BillService.MaxItems} items max).");
            return;
        }

        string description = AskString("Enter description: ");
        if (description.Length < 3 || description.Length > 20)
        {
            Console.WriteLine("Add item failed: description must be 3-20 characters long.");
            return;
        }

        string priceInput = AskString("Enter price: ");
        if (!decimal.TryParse(priceInput.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price) || price <= 0)
        {
            Console.WriteLine("Add item failed: price must be a positive number.");
            return;
        }

        bill.AddItem(description, price);
        Console.WriteLine("Add item was successful.");
    }
    public static void RemoveItem(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void AddTip(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void DisplayBill(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void ClearAll(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void SaveToFile(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void LoadFromFile(BillService bill) => Console.WriteLine("Not implemented yet.");
}