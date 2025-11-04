using System;

public class HealthRecord
{
    public DateTime Date { get; set; }
    public string Symptoms { get; set; }
    public string Treatment { get; set; }

    public HealthRecord() { }  // Needed for JSON deserialization

    public HealthRecord(DateTime date, string symptoms, string treatment)
    {
        Date = date;
        Symptoms = symptoms;
        Treatment = treatment;
    }
}
