using AssertiveResults.SampleTests.Samples;

namespace AssertiveResults.SampleTests;

public static class Sampling
{
    public static void Run()
    {
        Serilog.Log.Information("Starting...");
        // ResultMatching.Run();
        // ResultResolving.Run();
        ResultErrorStack.Run();
    }
}
