using System.Text.RegularExpressions;
using AssertiveResults;
using AssertiveResults.Errors;
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


        var result = Assertive.Result()
            .Assert(x => {
                var pwd = "&long";
                x.Regex.Match(pwd)
                    .Validates.PasswordStrength(PasswordStrength.Complex);
            })
            .Return();

        LogConsole(result);
        ErrorR();
    }

    private void LogConsole(IAssertiveResult result)
    {
        _logger.LogInformation("Status: {0}", result.Success ? "Success" : "Failed");
        _logger.LogInformation("Error(s): {0}", result.Errors.Count);

        if (result.Errors.Count > 0)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error [{0}][{1}]: {2}", error.ErrorType, error.Code, error.Description);
            }
        }
    }

    public void ErrorR()
    {
        var err1 = Error.Custom(1, "Err", "err");
        var err2 = Error.Custom(99, "WTF", "what-the-fuck");

        _logger.LogInformation("Error {0}", err1.ErrorType);
        _logger.LogInformation("Error {0}", err2.ErrorType);
    }
}