public class UserManager
{
    private List<User> users = new List<User>();

    public UserManager()
    {

        users.Add(new User("admin", "admin123", Role.Admin));
        users.Add(new User("Lillian", "user123", Role.User));
        users.Add(new User("Trulte", "Trulte123", Role.User));
        users.Add(new User("Fomle", "FiskenTilAriel", Role.User));
        users.Add(new User("Ariel", "Sjømonster", Role.User));
    }

    public User? Authenticate(string username, string password)
    {
        return users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
