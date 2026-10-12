using FluentResults;

namespace BidPulse.Domain.Common.ValueObjects;

public sealed record Money
{
    private Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
    private Money() { }

    public decimal Amount { get; private init; }
    public Currency Currency { get; private init; }

    public static Result<Money> Create(decimal amount, Currency currency)
    {
        if (amount < 0)
            return Errors.Validation("Money.Negative", "Amount cannot be negative.");
        return new Money(amount, currency);
    }
}
