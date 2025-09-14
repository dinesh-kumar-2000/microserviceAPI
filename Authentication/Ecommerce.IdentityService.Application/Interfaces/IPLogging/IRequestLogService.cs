namespace Ecommerce.IdentityService.Application.Interfaces.IPLogging;

public interface IRequestLogService
{
    Task LogRequestAsync(string ip, string path, string method);
}
