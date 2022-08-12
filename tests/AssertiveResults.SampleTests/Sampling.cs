using Microsoft.Extensions.Logging;

namespace AssertiveResults.SampleTests;

public class Sampling
{
    private readonly ILogger<Sampling> _logger;
    public Sampling(ILogger<Sampling> logger) => _logger = logger;

    public void Run()
    {
        _logger.LogInformation("Starting...");
    }
}
