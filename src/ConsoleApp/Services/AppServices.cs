using System.Text.RegularExpressions;
using AssertiveResults;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.Regex;
using ConsoleApp.Errors;
using ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

public class AppService : IAppService
{
    private readonly ILogger<AppService> _logger;
    public Database Database { get; set; }

    public AppService(ILogger<AppService> logger)
    {
        _logger = logger;
        Database = new Database();
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var register = new UserAccount(Guid.NewGuid(), "einharan", "mail@proton.me", "longpassword&0");
        var lookUp = Database.UserAccounts.Find(x => x.Username == register.Username);
        var result = Assertive.Result()
            .Assert(x => {
                var pwd = "&pwd";
                x.Should.Equal(pwd, "&pwd5");
            })
            .Finalize<Mock>(result =>
            {
                if(result.HasError)
                    _logger.LogCritical("HasError");
                else
                    _logger.LogInformation("HasNoError");

                return new Mock("Text");
            });

        LogConsole(result);
        _logger.LogInformation("Result: {result}", result.Value);
    }

    private void LogConsole(IAssertiveResult result)
    {
        _logger.LogInformation("Status: {result}", result.Success ? "Success" : "Failed");
        _logger.LogInformation("Error(s): {count}", result.Errors.Count);

        if (result.Errors.Count > 0)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error [{type}][{code}]: {message}", error.ErrorType, error.Code, error.Description);
            }
        }
    }
}