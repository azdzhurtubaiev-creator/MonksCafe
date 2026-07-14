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
    public static void RemoveItem(BillService bill)
    {
        if (bill.Items.Count == 0)
        {
            Console.WriteLine("There are no items in the bill to remove.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("ItemNo  Description               Price");
        Console.WriteLine("------  -----------              ------");
        for (int i = 0; i < bill.Items.Count; i++)
        {
            Console.WriteLine($"{i + 1,6}  {bill.Items[i].Description,-20} {bill.Items[i].Price,8:F2}");
        }

        string input = AskString("Enter the item number to remove or 0 to cancel: ");
        if (!int.TryParse(input, out int number))
        {
            Console.WriteLine("Remove item failed: please enter a valid number.");
            return;
        }

        if (number == 0)
        {
            Console.WriteLine("Remove was cancelled.");
            return;
        }

        if (number < 1 || number > bill.Items.Count)
        {
            Console.WriteLine($"Remove item failed: number must be between 1 and {bill.Items.Count}.");
            return;
        }

        bill.RemoveItemAt(number - 1);
        Console.WriteLine("Remove item was successful.");
    }
    public static void AddTip(BillService bill)
    {
        if (bill.Items.Count == 0)
        {
            Console.WriteLine("There are no items in the bill to add tip for.");
            return;
        }

        Console.WriteLine($"Net Total: {bill.GetNetTotal():F2}");
        Console.WriteLine("1 - Tip Percentage");
        Console.WriteLine("2 - Tip Amount");
        Console.WriteLine("3 - No Tip");
        string method = AskString("Enter Tip Method: ");

        switch (method)
        {
            case "1":
                string percentInput = AskString("Enter tip percentage: ");
                if (!decimal.TryParse(percentInput.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal percent) || percent < 0 || percent > 100)
                {
                    Console.WriteLine("Add tip failed: percentage must be a number between 0 and 100.");
                    return;
                }
                bill.SetTipPercentage(percent);
                Console.WriteLine("Tip was set successfully.");
                break;
            case "2":
                string amountInput = AskString("Enter Tip amount: ");
                if (!decimal.TryParse(amountInput.Replace(',', '.'), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount) || amount < 0)
                {
                    Console.WriteLine("Add tip failed: amount must be a non-negative number.");
                    return;
                }
                bill.SetTipAmount(amount);
                Console.WriteLine("Tip was set successfully.");
                break;
            case "3":
                bill.SetTipAmount(0m);
                Console.WriteLine("Tip was removed.");
                break;
            default:
                Console.WriteLine("Add tip failed: please choose 1, 2 or 3.");
                break;
        }
    }
    public static void DisplayBill(BillService bill)
    {
        if (bill.Items.Count == 0)
        {
            Console.WriteLine("There are no items in the bill to display.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Description               Price");
        Console.WriteLine("--------------------  ---------");
        foreach (BillItem item in bill.Items)
        {
            Console.WriteLine($"{item.Description,-20} {item.Price,9:F2}");
        }
        Console.WriteLine("--------------------  ---------");
        Console.WriteLine($"{"Net Total",17} {bill.GetNetTotal(),10:F2}");
        Console.WriteLine($"{"Tip Amount",17} {bill.TipAmount,10:F2}");
        Console.WriteLine($"{"GST Amount",17} {bill.GetGstAmount(),10:F2}");
        Console.WriteLine($"{"Total Amount",17} {bill.GetTotalAmount(),10:F2}");
    }
    public static void ClearAll(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void SaveToFile(BillService bill) => Console.WriteLine("Not implemented yet.");
    public static void LoadFromFile(BillService bill) => Console.WriteLine("Not implemented yet.");
}