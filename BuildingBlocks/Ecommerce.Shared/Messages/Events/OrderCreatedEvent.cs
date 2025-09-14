using Shared.Abstractions;

namespace Shared.Messages.Events;

public class OrderCreatedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime CreatedAt { get; set; }

    public Guid Id => throw new NotImplementedException();
}


