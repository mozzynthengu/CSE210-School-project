using System;

public class Sale
{
    public string ProductType { get; set; }
    public int Quantity { get; set; }
    public DateTime Date { get; set; }
    public Customer Customer { get; set; }

    public Sale(string productType, int quantity, DateTime date, Customer customer)
    {
        ProductType = productType;
        Quantity = quantity;
        Date = date;
        Customer = customer;
    }
}
