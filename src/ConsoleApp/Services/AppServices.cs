using System;
using System.Diagnostics;
using AssertiveResults;
using AssertiveResults.Errors;
using AssertiveResults.Assertions.RegularExpressions;
using AssertiveResults.Settings;
using ConsoleApp.Errors;
using ConsoleApp.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp.Services;

public class AppService : IAppService
{
    private readonly ILogger<AppService> _logger;
    public Database Database { get; set; }

    public AppService(ILogger<AppService> logger)
    {
        _logger = logger;
        Database = new Database();
    }

    private static IAssertiveResult DtoValidation(RegisterDto registerDto)
    {
        return Assertive.Result()
            .Assert(ctx => ctx.RegularExpression.Validates(registerDto.Username).Format.Username())
            .Assert(ctx => ctx.RegularExpression.Validates(registerDto.Password).Format.StrongPassword())
            .Assert(ctx => ctx.RegularExpression.Validates(registerDto.Email).Format.EmailAddress())
            .Resolve();
    }

    private IAssertiveResult<RegisterResult> Register(RegisterDto registerDto)
    {
        var result = DtoValidation(registerDto);
        return result.Override<RegisterResult>()
            .Assert(username =>
            {
                var userSearch = Database.Users.Find(x => x.Username == registerDto.Username);
                var isAvailable =  userSearch is null;
                username.Should.Satisfy(isAvailable).WithError(Conflict.UsernameTaken);
            })
            .Assert(email =>
            {
                var emailSearch = Database.Users.Find(x => x.Email == registerDto.Email);
                var isAvailable = emailSearch is null;
                email.Should.Satisfy(isAvailable).WithError(Conflict.EmailInUse);
            })
            .Resolve(_ =>
            {
                var accessToken = Guid.NewGuid().ToString();
                var user = new UserAccount(
                    Guid.NewGuid(),
                    registerDto.Username,
                    registerDto.Email,
                    registerDto.Password);

                return new RegisterResult(user.Id, user.Username, accessToken);
            });
    }

    public void Run2()
    {
        var registerDto = new RegisterDto("einharan", "einharan@mail.me", "longpassword123");

        var registerResult = Assertive.Result<RegisterResult>()
            .Assert(dto =>
            {
                dto.RegularExpression.Validates(registerDto.Username).Format.Username();
                dto.RegularExpression.Validates(registerDto.Password).Format.StrongPassword();
                dto.RegularExpression.Validates(registerDto.Email).Format.EmailAddress();
            })
            .Assert(username =>
            {
                var searchResult = Database.Users.Find(x => x.Username == registerDto.Username);
                var available =  searchResult is null;
                username.Should.Satisfy(available).WithError(Conflict.UsernameTaken);
            })
            .Assert(email =>
            {
                var searchResult = Database.Users.Find(x => x.Email == registerDto.Email);
                var available = searchResult is null;
                email.Should.Satisfy(available).WithError(Conflict.EmailInUse);
            })
            .Resolve(_ =>
            {
                var accessToken = Guid.NewGuid().ToString();
                var user = new UserAccount(
                    Guid.NewGuid(),
                    registerDto.Username,
                    registerDto.Email,
                    registerDto.Password);

                return new RegisterResult(user.Id, user.Username, accessToken);
            });
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var result = Assertive.Result<string>()
            .Assert(x => x.Should.Satisfy(true))
            .Assert(x => x.Should.Satisfy(true))
            .Assert(x => x.Should.Satisfy(true))
            .Resolve(_ => "TEXT");
        LogConsole(result);
        _logger.LogInformation("Value: {result}", result.Value);

        result.Overload()
            .Assert(x => x.Should.Satisfy(true))
            .Assert(x => x.Should.Satisfy(true))
            .Assert(x => x.Should.Satisfy(true))
            .Resolve(_ => "STRING");

        IAssertiveResult x = result.Override()
            .Assert(x => x.Should.Satisfy(true))
            .Resolve();

        IAssertiveResult<Mock> y = x.Override<Mock>()
            .Assert(x => x.Should.Satisfy(true))
            .Resolve(_ => new Mock("MOCK"));

        LogConsole(result);
        _logger.LogInformation("Value: {result}", result.Value);
        _logger.LogInformation("Override: {result}", result.Success);
        _logger.LogInformation("Override Value: {result}", y.Value);

        Run2();
    }

    private void LogConsole(IAssertiveResult result)
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