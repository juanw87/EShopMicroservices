namespace Ordering.Domain.Abstractions
{
    internal interface IAggregate<T> : IAggregate, IEntity<T>
    {

    }

    internal interface IAggregate : IEntity
    {
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
        IDomainEvent[] ClearDomainEvents();
    }
}
