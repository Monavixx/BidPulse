namespace BidPulse.Domain.Common;

public interface IEntity
{
    uint RowVersion { get; }
}
