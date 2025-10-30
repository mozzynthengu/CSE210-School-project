using System;

public class FeedInventory
{
    public string FeedName { get; set; }
    public double Quantity { get; set; }
    public double ReorderLevel { get; set; }

    public FeedInventory(string feedName, double quantity, double reorderLevel)
    {
        FeedName = feedName;
        Quantity = quantity;
        ReorderLevel = reorderLevel;
    }

    public void ConsumeFeed(double amount)
    {
        Quantity -= amount;
        if (Quantity < 0) Quantity = 0;
    }

    public bool CheckReorder()
    {
        return Quantity <= ReorderLevel;
    }
}
