using System.Diagnostics;
using AssertiveResults;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.RegularExpressions;
using AssertiveResults.Settings;
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

        AssertiveResult.Configure(opt =>
        {
            opt.SetDefaultBreakMethod(BreakMethod.Control);
        });
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        IAssertiveResult<string> result = Assertive.Result()
            .Assert(x => x.Should.Satisfy(true))
            .Assert(x => x.Should.Satisfy(true))
            .Assert(x => x.Should.Satisfy(true))
            .Resolve(_ => {
                return "text";
            });

        IAssertiveResult<int> resultInt = result.Extend()
            .Assert(x => x.Should.NotNull(result.Value))
            .Assert(x => x.Should.NotNull(null!))
            .Assert(x => x.Should.NotNull(null!))
            .Resolve(_ => 5);

        resultInt.Extend();

        // LogConsole(result);
        LogConsole(resultInt);
    }

    private void LogConsole(IAssertiveResult result)
    {
        _logger.LogInformation("Status: {result}", result.Success ? "Success" : "Failed");
        _logger.LogInformation("Error(s): {count}", result.Errors.Count);

        if (result.Failed)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error [{type}][{code}]: {message}", error.ErrorType, error.Code, error.Description);
            }
        }

        if(result.HasMetadata)
        {
            foreach (var metadata in result.Metadata)
            {
                _logger.LogCritical("[{key}]: {value}", metadata.Key, metadata.Value);
            }
        }
    }
}