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

        var register = new UserAccount(Guid.NewGuid(), "einharan", "mail@proton.me", "longpassword&0");
        var lookUp = Database.UserAccounts.FirstOrDefault(x => x.Username == register.Username);

        var pwd = "asd";

        var result = Assertive.Result()
            .Assert(x => {

                x.Regex.Must(pwd)
                    .Match(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            })
            .Return();

        LogConsole(result);
    }

    private void LogConsole(IAssertiveResult result)
    {
        _logger.LogInformation("Status: {0}", result.Success ? "Success" : "Failed");
        _logger.LogInformation("Error(s): {0}", result.Errors.Count);

        if (result.Errors.Count > 0)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error [{0}]: {1}", error.Code, error.Message);
            }
        }
    }

    public void Regex()
    {
        var regex = new Regex(@"[A-Z]+");
        var matches = regex.Matches("asdas");
        var match = regex.Match("Hello");
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

        var user = new UserAccount(Guid.NewGuid(), "einharan", "mail@proton.me", "&longpassword");

        var result = Assertive.Result()
            .Assert(x => {
                x.Must.Satisfy(user.Id != Guid.Empty);
            })
            .Assert(x => {
                // x.Regex.Match(user.Username).MinLength(1).WithError(Invalid.UsernameTooShort);
                // x.Regex.Match(user.Username).MaxLength(3).WithError(Invalid.UsernameTooLong);
                // x.Regex.Matches(user.Username).Length(min: 3, max: 5).WithError(Invalid.UsernameLength);
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
}