using System.ComponentModel.DataAnnotations;
using FluentResults;

namespace BidPulse.Domain.Common.ValueObjects;

public sealed record EmailAddress
{
    private EmailAddress() { }
    public string Value { get; private init; } = null!;

    private static readonly EmailAddressAttribute EmailAddressAttribute = new();

    public static Result<EmailAddress> Create(string emailAddress)
    {
        if (Validate(emailAddress) is { IsFailed: true } error)
            return error;
        return new EmailAddress { Value = emailAddress };
    }
    public static Result Validate(string emailAddress)
    {
        // Validate the email address using .net core built-in email validation
        if (!EmailAddressAttribute.IsValid(emailAddress))
        {
            return Errors.Validation("EmailAddress.Invalid", $"'{emailAddress}' is an invalid email address");
        }
        return Result.Ok();
    }
}
