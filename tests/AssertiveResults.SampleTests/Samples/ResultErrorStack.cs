using AssertiveResults.SampleTests.Errors;

namespace AssertiveResults.SampleTests.Samples;

public static class ResultErrorStack
{
    public static void Run()
    {
        var result = Assertive.Result()
            .Assert(ctx =>
            {
                ctx.Should.Satisfy(true).WithError(Error.Sampling.First);
                ctx.Should.Satisfy(false).WithError(Error.Sampling.Second);
                ctx.Should.Satisfy(false).WithError(Error.Sampling.Third);
            })
            .Resolve();

        result.Log();
    }
}
