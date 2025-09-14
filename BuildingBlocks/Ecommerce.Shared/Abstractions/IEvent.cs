namespace Shared.Abstractions;

public interface IEvent
{
    DateTime OccurredOn { get; }
}