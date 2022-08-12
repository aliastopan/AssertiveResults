namespace AssertiveResults.UnitTests.Results;

public class OverloadTests
{
    [Fact]
    public void NonGenericOverloadTest1()
    {
        bool condition = false;

        IResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.HasFailed);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(true))
            .Resolve();

        Assert.True(r1.HasFailed);
    }

    [Fact]
    public void NonGenericOverloadTest2()
    {
        bool condition = false;

        IResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.HasFailed);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.HasFailed);
    }

    [Fact]
    public void NonGenericOverloadTest3()
    {
        bool condition = false;

        IResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.HasFailed);

        IResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r2.HasFailed);
    }

    [Fact]
    public void NonGenericOverloadTest4()
    {
        bool condition = true;
        int counter  = 0;

        IResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(false))
            .Resolve();

        Assert.True(r1.HasFailed);

        IResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => {
                counter++;
                x.Should.Satisfy(false);
            })
            .Resolve();

        Assert.True(r2.HasFailed);
        Assert.True(counter == 0);
        Assert.True(r2.Errors.Count == 1);
    }

    [Fact]
    public void NonGenericOverloadTest5()
    {
        bool condition = true;

        IResult r1 = Assertive.Result()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r1.IsSuccess);

        IResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve();

        Assert.True(r2.IsSuccess);
        Assert.True(r2.Errors.Count == 0);
    }

    [Fact]
    public void GenericOverloadTest1()
    {
        bool condition = true;

        IResult<string> r1 = Assertive.Result<string>()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve(_ => "TEXT");

        Assert.True(r1.IsSuccess);

        IResult r2 = r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(false))
            .Resolve(_ => r1.Value);

        Assert.True(r2.HasFailed);
        Assert.Equal(default, r1.Value);
    }

    [Fact]
    public void GenericOverloadTest2()
    {
        bool condition = true;

        IResult<string> r1 = Assertive.Result<string>()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve(_ => "TEXT");

        Assert.True(r1.IsSuccess);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(false))
            .Resolve(_ => r1.Value);

        Assert.True(r1.HasFailed);
        Assert.Equal(default, r1.Value);
    }

    [Fact]
    public void GenericOverloadTest3()
    {
        bool condition = true;

        IResult<string> r1 = Assertive.Result<string>()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve(_ => "TEXT");

        Assert.True(r1.IsSuccess);

        r1.Overload()
            .Assert(x => x.Should.Satisfy(condition))
            .Assert(x => x.Should.Satisfy(condition))
            .Resolve(_ => r1.Value);

        Assert.True(r1.IsSuccess);
        Assert.True(r1.Value == "TEXT");
    }
}
