using BidPulse.Domain.Common;
using BidPulse.Domain.Common.ValueObjects;

namespace BidPulse.Domain.Aggregates.Users;

public sealed class UserDeliveryAddress : Entity
{
    private UserDeliveryAddress() { }

    public Guid UserId { get; private set; }
    public Address Address { get; private set; } = null!;
    public string? AdditionalInformation { get; private set; }

}
