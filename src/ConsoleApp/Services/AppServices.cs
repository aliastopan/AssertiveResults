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

        string user = "einharan";
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinimum8Chars = new Regex(@".{8,}");

        var x = hasNumber.IsMatch(user);

        var result = Assertive.Result()
            .Assert(x => {
                x.True(hasNumber.IsMatch(user)).WithError("Must have number.");
                x.True(hasUpperChar.IsMatch(user)).WithError("Must have Uppercase character.");
                x.True(hasMinimum8Chars.IsMatch(user)).WithError("Must at least 8 characters.");
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