using Shared.Abstractions;

namespace Shared.Messages.Events;

public class PaymentFailedEvent : IIntegrationEvent
{
    public Guid OrderId { get; set; }
    public string FailureReason { get; set; }
    public DateTime Timestamp { get; set; }

    public Guid Id => throw new NotImplementedException();

    public DateTime CreatedAt => throw new NotImplementedException();
}


