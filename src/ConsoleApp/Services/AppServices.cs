using AssertiveResults;
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

        string user = null!;

        var result = Assertive.Result()
            .Assert(x => {
                x.Null(user);
            })
            .Return();

        _logger.LogInformation("Error(s): {0}", result.Errors.Count);
    }
}