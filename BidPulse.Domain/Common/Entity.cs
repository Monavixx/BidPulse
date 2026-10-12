namespace BidPulse.Domain.Common;

public abstract class Entity<TId>(TId id) : IEntity
    where TId : notnull
{
    public uint RowVersion { get; private set; }
    public TId Id { get; protected init; } = id;
}

public abstract class Entity : Entity<Guid>
{
    public Entity(Guid id) : base(id) { }
    public Entity() : base(Guid.CreateVersion7()) { }
}
