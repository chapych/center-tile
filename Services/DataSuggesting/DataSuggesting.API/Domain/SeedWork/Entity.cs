namespace DataSuggesting.API.Domain.SeedWork;

public abstract class Entity<T>
{
    public T Id { get; protected init; }
    
    private List<IDomainNotification> _domainEvents;
    public IReadOnlyCollection<IDomainNotification> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainNotification notificationItem)
    {
        _domainEvents = _domainEvents ?? [];
        _domainEvents.Add(notificationItem);
    }
}