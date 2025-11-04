public class Animal
{
    public int Id { get; set; }
    public int Age { get; set; }

    public Animal() { }  // Needed for JSON deserialization

    public Animal(int id, int age)
    {
        Id = id;
        Age = age;
    }
}
