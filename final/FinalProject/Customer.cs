using System.Collections.Generic;

public class Customer
{
    public string Name { get; set; }
    public string Contact { get; set; }
    public List<Sale> Purchases { get; set; }

    public Customer() 
    { 
        Purchases = new List<Sale>(); 
    }

    public Customer(string name, string contact)
    {
        Name = name;
        Contact = contact;
        Purchases = new List<Sale>();
    }

    public void AddPurchase(Sale sale)
    {
        Purchases.Add(sale);
    }

    public string GetCustomerInfo()
    {
        return $"{Name} ({Contact})";
    }
}
