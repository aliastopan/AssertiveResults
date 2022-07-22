using System.Text.RegularExpressions;
using AssertiveResults;
using ConsoleApp.Errors;
using ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

public class AppService : IAppService
{
    private readonly ILogger<AppService> _logger;
    private readonly IConfiguration _config;
    public Database Database { get; set; }

    public AppService(ILogger<AppService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
        Database = new Database();
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var user = new UserAccount(Guid.Empty, "einharan", "mail@proton.me", "&longpassword");

        var result = Assertive.Result()
            .Assert(x => {
                x.Must.Satisfy(user.Id != Guid.Empty).WithError($"GUID cannot be {Guid.Empty}.");
                x.Must.NotSatisfy(false);
            })
            .Assert(x => {
                x.Regex.Match(user.password, @"[0-9]+").WithError(Invalid.PasswordFormat);
                x.Regex.Match(user.password, @"[a-z]+").WithError("Must have lower character.");
                x.Regex.NotMatch(user.password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]").WithError("Must not have special characters");
            })
            .Return();

        _logger.LogInformation("Status: {0}", result.Success ? "Success" : "Failed");
        _logger.LogInformation("Error(s): {0}", result.Errors.Count);

        if(result.Errors.Count > 0)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error: {0}", error.Message);
            }
        }
    }

    public void RegularExpression()
    {
        var hasMinChar = new Regex(@".{8,}");
        var hasMaxChar = new Regex(@".{8,15}");
        var hasNumber = new Regex(@"[0-9]+");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasSpecialChar = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

        var regex = hasMaxChar.Match("einharan");
    }
}