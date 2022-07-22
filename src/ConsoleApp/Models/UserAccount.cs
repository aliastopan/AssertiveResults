namespace ConsoleApp.Models;

public record UserAccount(
    Guid Id,
    string Username,
    string Email,
    string password
);