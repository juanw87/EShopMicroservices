namespace Ordering.Application.Orders.EventHandlers.Domain;
public class OrderUpdatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderUpdateEvent>
{
    public Task Handle(OrderUpdateEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain event handler: {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
