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
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var result = Assertive.Result()
            .Assert(x => {
                var pwd = "&pwd";
                x.Should.Equal(pwd, "&pwd5").WithError(Errors.Conflict.UsernameTaken);
            })
            .Resolve<Mock>(_ =>
            {
                return new Mock("Text");
            });

        // result
        //     .WithMetadata("Timestamp", DateTime.UtcNow)
        //     .WithMetadata("TraceId", Activity.Current?.Id ?? Guid.NewGuid().ToString());

        // var traceId = result.GetMetadata("TraceId");

        LogConsole(result);
        // _logger.LogInformation("TraceId: {traceId}", traceId);
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