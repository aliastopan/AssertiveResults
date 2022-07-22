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

        var hasMinChar = new Regex(@".{8,}");
        var hasMaxChar = new Regex(@".{8,15}");
        var hasNumber = new Regex(@"[0-9]+");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        var user = new UserAccount(Guid.Empty, "einharan", "mail@proton.me", "longpassword");

        var result = Assertive.Result()
            .Assert(x => {
                x.Must.Satisfy(true);
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

        // var result = Assertive.Result()
        //     .Assert(x => {
        //         var lookUp = Database.UserAccounts.FirstOrDefault(x => x.Username == user.Username);
        //         x.Null(lookUp).WithError("Username is already taken.");
        //     })
        //     .Break()
        //     .Assert(x => {
        //         x.Match(user.password, @"[0-9]+").WithError("Must have number.");
        //         x.Match(user.password, @"[A-Z]+").WithError("Must have uppercase character.");
        //         x.Match(user.password, @"[a-z]+").WithError("Must have lower character.");
        //     })
        //     .Return();

    }
}