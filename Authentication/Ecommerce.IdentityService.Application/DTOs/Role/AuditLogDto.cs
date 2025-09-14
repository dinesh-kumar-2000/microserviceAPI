namespace Ecommerce.IdentityService.Application.DTOs.Role;

public class AuditLogDto
{
    public long Id { get; set; }
    public Guid? UserId { get; set; }
    public string EventType { get; set; }
    public string? EventData { get; set; }
    public DateTimeOffset OccurredAt { get; set; }
}
