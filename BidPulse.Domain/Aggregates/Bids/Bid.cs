using BidPulse.Domain.Common;
using BidPulse.Domain.Common.ValueObjects;

namespace BidPulse.Domain.Aggregates.Bids;

public sealed class Bid : AggregateRoot
{
    private Bid() { }

    public Guid BidderId { get; private set; }
    public Guid AuctionId { get; private set; }
    public DateTime BidAt { get; private set; }
    public Money Price { get; private set; } = null!;


}
