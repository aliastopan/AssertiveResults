namespace AssertiveResults.UnitTests.Assertion;

public class Dummy : IComparable<Dummy>
{
    public int Id { get; set; }
    public string Content { get; set; }

    public Dummy(int id, string content)
    {
        Id = id;
        Content = content;
    }

    public int CompareTo(Dummy? other)
    {
        if(other!.Id > this.Id)
            return 1;
        if(other!.Id < this.Id)
            return -1;
        else
            return 0;
    }
}

public class AssertStrictEqual
{
    [Fact]
    public void Should_StrictEqual()
    {
        var result = Assertive.Result()
            .Assert((Action<Assertions.IContext>)(x => {
                var former = new Dummy(1, "text");
                var latter = new Dummy(1, "plain/text");
                x.Should.StrictEqual<Dummy>(former, latter);
            }))
            .Resolve();

        Assert.True(result.Success);
    }

    [Fact]
    public void Should_NotStrictEqual()
    {
        var result = Assertive.Result()
            .Assert((Action<Assertions.IContext>)(x => {
                var former = new Dummy(1, "text");
                var latter = new Dummy(2, "text");
                x.Should.NotStrictEqual<Dummy>(former, latter);
            }))
            .Resolve();

        Assert.True(result.Success);
    }
}