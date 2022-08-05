using AssertiveResults;
using AssertiveResults.Settings;

namespace AssertiveResults.UnitTests;

public class AssertiveResultTests
{
    private readonly ITestOutputHelper output;

    public AssertiveResultTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void NonGenericOverloadTest1()
    {
        bool condition = false;

        IAssertiveResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.Failed);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(true))
            .Resolve();

        Assert.True(r1.Failed);
        Assert.True(r1.Errors.Count == 3);
    }

    [Fact]
    public void NonGenericOverloadTest2()
    {
        bool condition = false;

        IAssertiveResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.Failed);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.Failed);
        Assert.True(r1.Errors.Count == 6);
    }

    [Fact]
    public void NonGenericOverloadTest3()
    {
        bool condition = false;

        IAssertiveResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.Failed);

        IAssertiveResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r2.Failed);
        Assert.True(r2.Errors.Count == 6);
    }

    [Fact]
    public void NonGenericOverloadTest4()
    {
        bool condition = true;
        int counter  = 0;

        IAssertiveResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(false))
            .Resolve();

        Assert.True(r1.Failed);

        IAssertiveResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => {
                counter++;
                x.Should.Satisfy(false);
            })
            .Resolve();

        Assert.True(r2.Failed);
        Assert.True(counter == 0);
        Assert.True(r2.Errors.Count == 1);
    }

    [Fact]
    public void NonGenericOverloadTest5()
    {
        bool condition = true;

        IAssertiveResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.Success);

        IAssertiveResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r2.Success);
        Assert.True(r2.Errors.Count == 0);
    }

    [Fact]
    public void NonGenericOverloadTest6()
    {
        bool condition = true;

        IAssertiveResult<string> r1 = Assertive.Result<string>()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve(_ => "TEXT");

        Assert.True(r1.Success);

        IAssertiveResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(false))
            .Resolve(_ => r1.Value);

        Assert.True(r2.Failed);
        Assert.True(r1.Value == "TEXT");
    }

    [Fact]
    public void NonGenericOverloadTest7()
    {
        bool condition = true;

        IAssertiveResult<string> r1 = Assertive.Result<string>()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve(_ => "TEXT");

        Assert.True(r1.Success);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(false))
            .Resolve(_ => r1.Value);

        Assert.True(r1.Failed);
        output.WriteLine($"Output: {r1.Value}");
        Assert.True(r1.Value != null);
    }
}
