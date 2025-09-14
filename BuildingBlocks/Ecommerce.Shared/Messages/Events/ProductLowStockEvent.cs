using Shared.Abstractions;

namespace Shared.Messages.Events;

public class ProductLowStockEvent : IIntegrationEvent
{
    public Guid ProductId { get; set; }
    public int CurrentStock { get; set; }

    public Guid Id => throw new NotImplementedException();

    public DateTime CreatedAt => throw new NotImplementedException();
}


