using System;
using System.Collections.Generic;
using System.Linq;

public class FarmReport
{
    public string GenerateSalesReport(List<Sale> sales)
    {
        if (sales.Count == 0) return "No sales recorded.";

        var report = "=== Sales Report ===\n";
        foreach (var sale in sales)
        {
            report += $"{sale.Date.ToShortDateString()}: {sale.Quantity} {sale.ProductType} sold to {sale.Customer.Name}\n";
        }
        return report;
    }

    public string GenerateHealthReport(List<HealthRecord> healthRecords)
    {
        if (healthRecords.Count == 0) return "No health issues recorded.";

        var report = "=== Health Report ===\n";
        foreach (var record in healthRecords)
        {
            report += $"{record.Date.ToShortDateString()}: Symptoms - {record.Symptoms}, Treatment - {record.Treatment}\n";
        }
        return report;
    }

    public string GenerateFeedUsageReport(FeedInventory feedInventory)
    {
        return $"=== Feed Report ===\nFeed: {feedInventory.FeedName}\nQuantity Remaining: {feedInventory.Quantity} kg\nReorder Level: {feedInventory.ReorderLevel} kg";
    }
}
