using System.Collections.Generic;

public class Chicken : Animal
{
    public string Type { get; set; }
    public List<EggProduction> EggRecords { get; set; }

    public Chicken() 
    { 
        EggRecords = new List<EggProduction>(); 
    }

    public Chicken(int id, int age, string type) : base(id, age)
    {
        Type = type;
        EggRecords = new List<EggProduction>();
    }

    public void AddEggProductionRecord(EggProduction record)
    {
        EggRecords.Add(record);
    }
}
