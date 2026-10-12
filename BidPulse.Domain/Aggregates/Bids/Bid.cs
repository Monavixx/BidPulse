using BidPulse.Domain.Common;
using BidPulse.Domain.Common.ValueObjects;
using FluentResults;

namespace BidPulse.Domain.Aggregates.Bids;

public sealed class Bid : AggregateRoot
{
    private Bid() { }

    public Guid BidderId { get; private set; }
    public Guid AuctionId { get; private set; }
    public DateTime BidAt { get; private set; }
    public Money Price { get; private set; } = null!;

    public static Bid Create(Guid bidderId, Guid auctionId, Money price, TimeProvider timeProvider)
    {
        ArgumentNullException.ThrowIfNull(price);
        return new Bid
        {
            BidderId = bidderId,
            AuctionId = auctionId,
            Price = price,
            BidAt = timeProvider.GetUtcNow().DateTime
        };
    }
    public static Result<Bid> Create(Guid bidderId, Guid auctionId, decimal priceAmount, Currency priceCurrency, TimeProvider timeProvider)
    {
        var moneyRes = Money.Create(priceAmount, priceCurrency);
        if (moneyRes.IsFailed) return moneyRes.ToResult();
        return Create(bidderId, auctionId, moneyRes.Value, timeProvider);
    }
}
