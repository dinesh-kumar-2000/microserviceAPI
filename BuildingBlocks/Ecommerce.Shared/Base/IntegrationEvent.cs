using Shared.Abstractions;

namespace Shared.Base;

public abstract class IntegrationEvent : IIntegrationEvent
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
}