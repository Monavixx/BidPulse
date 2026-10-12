using BidPulse.Domain.Common;
using FluentResults;

namespace BidPulse.Domain.Aggregates.Users;

public sealed record Username
{
    public const int MinLength = 3;
    public const int MaxLength = 50;
    private Username() { }

    public string Value { get; private init; } = null!;
    public static Result<Username> Create(string username)
    {
        var validation = Validate(username);
        if (validation.IsFailed)
        {
            return Result.Fail<Username>(validation.Errors);
        }

        return new Username { Value = username };
    }
    public Result Validate() => Validate(Value);

    public static Result Validate(string? username)
    {
        // Username cannot contain any white space symbols.
        if (username is null || username.Any(char.IsWhiteSpace))
        {
            return Errors.Validation("Username.WhiteSpace", "Username cannot contain any white space symbols.");
        }

        // Username must contain only these characters: english letters, numbers, - (dash), _ (underscore)
        if (!username.All(c => char.IsLetterOrDigit(c) || c is '-' or '_'))
        {
            return Errors.Validation("Username.InvalidCharacters", "Username must contain only these characters: english letters, numbers, - (dash), _ (underscore).");
        }

        // Username's length should be between MinLength and MaxLength including
        if (username.Length is < MinLength or > MaxLength)
        {
            return Errors.Validation("Username.InvalidLength", $"Username's length should be between {MinLength} and {MaxLength} including.");
        }

        return Result.Ok();
    }
}
