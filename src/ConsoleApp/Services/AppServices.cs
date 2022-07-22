using System.Text.RegularExpressions;
using AssertiveResults;
using ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

public class AppService : IAppService
{
    private readonly ILogger<AppService> _logger;
    private readonly IConfiguration _config;

    public AppService(ILogger<AppService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var hasMinChar = new Regex(@".{8,}");
        var hasMaxChar = new Regex(@".{8,15}");
        var hasNumber = new Regex(@"[0-9]+");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

        var user = new UserAccount(Guid.Empty, "einharan", "mail@proton.me", "!longpassword+");

        var result = Assertive.Result()
            .Assert(x => {
                x.Match(user.password, @"[0-9]+").WithError("Must have number.");
                x.Match(user.password, @"[a-z]+").WithError("Must have uppercase character.");
                x.Match(user.password, @"[A-Z]+").WithError("Must have lower character.");
            })
            .Return();

        var verdict = result.Success ? "Success" : "Failed";
        _logger.LogInformation("Status: {0}", verdict);
        _logger.LogInformation("Error(s): {0}", result.Errors.Count);

        if(result.Errors.Count > 0)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error: {0}", error.Message);
            }
        }
    }

    public void Module()
    {
        var username = new Mock("_einharan");
        var email = new Mock("_@mail");
        var password = new Mock("longpassword");

        var mocks = new List<Mock>(){ username, email, password };

        var result = Assertive.Result()
            .Assert(assert => {
                var lookUp = mocks.FirstOrDefault(v => v.Value == "einharan");
                assert.Null(lookUp).WithError("Username is already taken.");
            })
            .Assert(x => {
                var lookUp = mocks.FirstOrDefault(v => v.Value == "@mail");
                x.Null(lookUp).WithError("Email is already in use.");
            })
            .Assert(x =>
            {
                x.NotNull(password.Value);
            })
            .Return<Mock>(username);

        var verdict = result.Success ? "Success" : "Failed";
        _logger.LogInformation("Status: {0}", verdict);
        _logger.LogInformation("Error(s): {0}", result.Errors.Count);

        foreach (var error in result.Errors)
        {
            _logger.LogWarning("Error: {0}", error.Message);
        }

        _logger.LogInformation("Result: {0}", result.Value);
    }
}