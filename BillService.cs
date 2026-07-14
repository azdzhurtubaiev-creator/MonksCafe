namespace MonksCafe;

public class BillItem
{
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
}

public class BillService
{
    public const int MaxItems = 5;
    public const decimal GstRate = 0.05m;

    private readonly List<BillItem> items = new List<BillItem>();
    private decimal tipAmount = 0m;

    public IReadOnlyList<BillItem> Items => items;
    public decimal TipAmount => tipAmount;

    public decimal GetNetTotal()
    {
        decimal total = 0m;
        foreach (BillItem item in items)
        {
            total += item.Price;
        }
        return total;
    }

    public decimal GetGstAmount() => GetNetTotal() * GstRate;

    public decimal GetTotalAmount() => GetNetTotal() + tipAmount + GetGstAmount();

    public bool AddItem(string description, decimal price)
    {
        if (items.Count >= MaxItems)
        {
            return false;
        }
        items.Add(new BillItem { Description = description, Price = price });
        return true;
    }

    public void RemoveItemAt(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }
}