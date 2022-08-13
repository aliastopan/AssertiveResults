namespace AssertiveResults.SampleTests;

public static class Sampling
{
    public static void Run()
    {
        Serilog.Log.Information("Starting...");

        var result = Assertive.Result<string>()
            .Assert(ctx => ctx.Should.Satisfy(false))
            .Resolve(_ =>
            {
                return "sampling";
            });

        result.Match(
            ok => Serilog.Log.Information("Success<T>: {0}", ok.value),
            fail => Serilog.Log.Information("Failure<T>: {0}", fail.problem.FirstError.Description)
        );

        var check = Assertive.Result()
            .Assert(ctx => ctx.Should.Satisfy(true))
            .Resolve()
            .WithMetadata("user", "einharan")
            .WithMetadata("timestamp", DateTime.UtcNow);

        check.Match(
            _ => Serilog.Log.Information("Success: {0}", _.GetMetadata("user")),
            _ => Serilog.Log.Information("Failure: {0}", _.metadata.GetMetadata("timestamp"))
        );

        result.Log();
    }
}
