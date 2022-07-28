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
                x.Should.Equal(pwd, "&pwd");
                x.Should.Equal(pwd, "&pwd").WithErrorDefault("Password");
                // x.Should.Equal(pwd, "&pwd").WithErrorDefault(errorCode: "500");
                // x.Should.Equal(pwd, "&pwd").WithErrorDefault("Password", "500");
            })
            // .Assert(x => {
            //     var pwd = "&long";
            //     x.Regex.Match(pwd).Contains.UpperCase();
            //     x.Regex.Match(pwd).Contains.UpperCase().WithErrorDefault("Password");
            //     x.Regex.Match(pwd).Contains.UpperCase().WithErrorDefault(errorCode: "334");
            //     x.Regex.Match(pwd).Contains.UpperCase().WithErrorDefault("Password", "334");
            // })
            // .Assert(x => {
            //     x.Should.Null(register);
            //     x.Should.Null(register).WithErrorDefault("NewPassword");
            //     x.Should.Null(register).WithErrorDefault(errorCode: "880");
            //     x.Should.Null(register).WithErrorDefault("NewPassword", "880");
            // })
            .Return();

        LogConsole(result);
        // ErrorR();

        // _logger.LogInformation("Expression: {0}", Expression.Length(3,8));
        // _logger.LogInformation("Expression: {0}", Expression.MinLength(3));
        // _logger.LogInformation("Expression: {0}", Expression.MaxLength(8));

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