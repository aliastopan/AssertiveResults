using System;
using System.Diagnostics;
using AssertiveResults;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.RegularExpressions;
using ConsoleApp.Errors;
using ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

internal static class Assert
{
    internal static ISubject ValidateDto(RegisterDto registerDto)
    {
        return Assertive.Result()
            .Assert(ctx => ctx.RegularExpression.Validate(registerDto.Username).Format.Username())
            .Assert(ctx => ctx.RegularExpression.Validate(registerDto.Password).Format.StrongPassword())
            .Assert(ctx => ctx.RegularExpression.Validate(registerDto.Email).Format.EmailAddress());
    }

    internal static ISubject UserAvailability(this ISubject subject, Database database, string username)
    {
        return subject.Assert(ctx =>
        {
            var userSearch = database.Users.Find(x => x.Username == username);
            var available =  userSearch is null;
            ctx.Should.Satisfy(available).WithError(Conflict.UsernameTaken);
        });
    }

    internal static ISubject EmailAvailability(this ISubject step, Database database, string email)
    {
        return step.Assert(ctx => {
            var emailSearch = database.Users.Find(x => x.Email == email);
            var available =  emailSearch is null;
            ctx.Should.Satisfy(available).WithError(Conflict.UsernameTaken);
        });
    }
}

public class AppService : IAppService
{
    private readonly ILogger<AppService> _logger;
    public Database Database { get; set; }

    public AppService(ILogger<AppService> logger)
    {
        _logger = logger;
        Database = new Database();
    }

    private IResult<RegisterResult> RegisterUser(RegisterDto registerDto)
    {
        var step1 = Assert.ValidateDto(registerDto);
        var step2 = step1.UserAvailability(Database, registerDto.Username);
        var step3 = step2.EmailAvailability(Database, registerDto.Email);
        var step4 = step3.Override<RegisterResult>();

        var registerResult = step4.Resolve(ResolveBehavior.Control, _ => {
            var accessToken = Guid.NewGuid().ToString();
            var user = new UserAccount(
                Guid.NewGuid(),
                registerDto.Username,
                registerDto.Email,
                registerDto.Password);
            Console.WriteLine("CALLED");
            _.PurgeErrors();
            return new RegisterResult(user.Id, user.Username, accessToken);
        });

        return registerResult;
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var result0 = Assertive.Result()
            .Assert(_ => _.Exception.Catch(Errors.Conflict.EmailInUse))
            .Resolve();

        LogConsole(result0);
    }

    public void Run2()
    {
        _logger.LogInformation("Starting...");

        var registerDto = new RegisterDto("einharan", "einharan@proton.met", "longpassword123");
        var result = RegisterUser(registerDto);
        LogConsole(result);
        _logger.LogInformation("Value: {value}", result.Value);
    }

    private void LogConsole(AssertiveResults.IResult result)
    {
        _logger.LogInformation("Status: {result}", result.Success ? "Success" : "Failed");
        _logger.LogInformation("Error(s): {count}", result.Errors.Count);

        if (result.Failed)
        {
            foreach (var error in result.Errors)
            {
                _logger.LogWarning("Error [{type}][{code}]: {message}", error.ErrorType, error.Code, error.Description);
            }
        }

        if(result.HasMetadata)
        {
            foreach (var metadata in result.Metadata)
            {
                _logger.LogCritical("[{key}]: {value}", metadata.Key, metadata.Value);
            }
        }
    }
}