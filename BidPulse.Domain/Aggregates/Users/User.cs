using BidPulse.Domain.Common;
using BidPulse.Domain.Common.ValueObjects;
using FluentResults;

namespace BidPulse.Domain.Aggregates.Users;

public class User : AggregateRoot
{
    public Username Username { get; private set; } = null!;
    public EmailAddress EmailAddress { get; private set; } = null!;

    public static Result<User> Create(string username, string emailAddress)
    {
        var usernameResult = Username.Create(username);
        if (usernameResult.IsFailed)
            return usernameResult.ToResult();

        var emailAddressResult = EmailAddress.Create(emailAddress);
        if (emailAddressResult.IsFailed)
            return emailAddressResult.ToResult();

        return Create(usernameResult.Value, emailAddressResult.Value);
    }

    public static Result<User> Create(Username username, EmailAddress emailAddress)
    {
        ArgumentNullException.ThrowIfNull(username);
        ArgumentNullException.ThrowIfNull(emailAddress);
        return new User { Username = username, EmailAddress = emailAddress };
    }
}
