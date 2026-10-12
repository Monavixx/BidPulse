namespace BidPulse.Domain.Common;

public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id)
    where TId : notnull
{

}

public abstract class AggregateRoot : AggregateRoot<Guid>
{
    public AggregateRoot(Guid id) : base(id) { }
    public AggregateRoot() : base(Guid.CreateVersion7()) { }
}
