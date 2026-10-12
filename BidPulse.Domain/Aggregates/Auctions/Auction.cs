using BidPulse.Domain.Common;
using BidPulse.Domain.Common.ValueObjects;

namespace BidPulse.Domain.Aggregates.Auctions;

public sealed class Auction : AggregateRoot
{
    private Auction() { }

    public Guid SellerId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Money InitialPrice { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime StartsAt { get; private set; }
    public DateTime EndsAt { get; private set; }
    public AuctionStatus State { get; private set; }
}
