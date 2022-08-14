namespace AssertiveResults.SampleTests;

public static class Logging
{
    public static void Log(this IResult result)
    {
        Serilog.Log.Logger.Information("Status: {result}", result.IsSuccess ? "Success" : "Failed");
        Serilog.Log.Logger.Information("Error(s): {count}", result.Errors.Count);

        if (result.HasFailed)
        {
            foreach (var error in result.Errors)
            {
                Serilog.Log.Logger.Information(
                    "Error [{title}]: {detail}",
                    error.Title,
                    error.Detail);
            }
        }

        if(result.HasMetadata)
        {
            foreach (var metadata in result.Metadata)
            {
                Serilog.Log.Logger.Information(
                    "[{key}]: {value}",
                    metadata.Key,
                    metadata.Value);
            }
        }
    }
}
