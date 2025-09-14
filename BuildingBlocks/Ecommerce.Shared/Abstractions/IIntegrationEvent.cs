namespace Shared.Abstractions;

public interface IIntegrationEvent
{
    Guid Id { get; }
    DateTime CreatedAt { get; }
}