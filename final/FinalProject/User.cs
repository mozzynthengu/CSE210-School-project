public class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User() { }  // Needed for JSON deserialization

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
}
