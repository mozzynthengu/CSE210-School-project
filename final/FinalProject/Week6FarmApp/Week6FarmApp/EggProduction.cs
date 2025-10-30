using System;

public class EggProduction
{
    public DateTime Date { get; set; }
    public int Quantity { get; set; }

    public EggProduction(DateTime date, int quantity)
    {
        Date = date;
        Quantity = quantity;
    }
}
