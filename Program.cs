namespace MonksCafe;

public static class Program
{
    public static void Main()
    {
        BillService bill = new BillService();
        bool isRunning = true;

        while (isRunning)
        {
            Ui.ShowMenu();
            string choice = Ui.AskString("Enter your choice: ");

            switch (choice)
            {
                case "1": Ui.AddItem(bill); break;
                case "2": Ui.RemoveItem(bill); break;
                case "3": Ui.AddTip(bill); break;
                case "4": Ui.DisplayBill(bill); break;
                case "5": Ui.ClearAll(bill); break;
                case "6": Ui.SaveToFile(bill); break;
                case "7": Ui.LoadFromFile(bill); break;
                case "0":
                    Console.WriteLine("Good-bye and thanks for using this program.");
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Unknown choice. Please enter a number from the menu.");
                    break;
            }
        }
    }
}