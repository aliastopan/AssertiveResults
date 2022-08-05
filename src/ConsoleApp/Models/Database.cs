namespace ConsoleApp.Models;

public class Database
{
    public List<UserAccount> Users { get; set; }

    public Database()
    {
        Users = new List<UserAccount>()
        {
            new UserAccount(Guid.NewGuid(), "einharan", "mail@proton.me", "longpassword"),
            new UserAccount(Guid.NewGuid(), "oskar", "oskra@proton.me", "verylongpassword"),
            new UserAccount(Guid.NewGuid(), "vincent", "dev.work@proton.me", "sudopseudo"),
        };
    }
}
