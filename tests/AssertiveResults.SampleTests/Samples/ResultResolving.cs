using AssertiveResults.SampleTests.Errors;

namespace AssertiveResults.SampleTests.Samples;

public static class ResultResolving
{
    public static void Run()
    {
        var result = Assertive.Result<string>()
            .Assert(ctx =>
            {
                ctx.Should.Satisfy(false).WithError(Error.Authentication.UserNotFound);
            })
            .Resolve(ResolveBehavior.Strict, _ =>
            {
                Serilog.Log.Warning("Behavior.Control");
                return "resolve.strict";
            });

        result.Log();

        result.Match(
            ok => Serilog.Log.Information("Success<{1}>: {0}", ok.value, ok.value.GetType().Name),
            fail => Serilog.Log.Information("Failure<{1}>: {0}", fail.problem.FirstError.Detail, fail.problem.FirstError.GetType().Name)
        );
    }
}
