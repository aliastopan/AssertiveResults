namespace AssertiveResults.SampleTests.Samples;

public static class ResultMatching
{
    public static void Run()
    {
        var result = Assertive.Result<string>()
            .Assert(ctx => ctx.Should.Satisfy(true))
            .Resolve(_ =>
            {
                return "sampling";
            });

        result.Match(
            ok => Serilog.Log.Information("Success<T>: {0}", ok.value),
            fail => Serilog.Log.Information("Failure<T>: {0}", fail.problem.FirstError.Description)
        );

        var matchResult = result.Match(
            ok => ok.value,
            fail => fail.problem.FirstError.Code
        );

        Serilog.Log.Information("Match: {0}", matchResult);

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
