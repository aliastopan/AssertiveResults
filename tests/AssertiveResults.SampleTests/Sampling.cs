namespace AssertiveResults.SampleTests;

public static class Sampling
{
    public static void Run()
    {
        Serilog.Log.Information("Starting...");

        var result = Assertive.Result<string>()
            .Assert(ctx => ctx.Should.Satisfy(true))
            .Resolve(_ =>
            {
                return "sampling";
            });

        result.Log();
    }
}
