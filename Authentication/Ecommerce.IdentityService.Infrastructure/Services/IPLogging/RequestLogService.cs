using Ecommerce.IdentityService.Application.Interfaces.IPLogging;
using Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.DapperRepository;

namespace Ecommerce.IdentityService.Infrastructure.Services.IPLogging;

public class RequestLogService : IRequestLogService
{
    private readonly DapperRepository _db;

    public RequestLogService(DapperRepository db)
    {
        _db = db;
    }

    public async Task LogRequestAsync(string ip, string path, string method)
    {
        var sql = @"INSERT INTO RequestLogs (Id, IPAddress, Path, Method, Timestamp)
                    VALUES (@Id, @IPAddress, @Path, @Method, @Timestamp)";

        await _db.ExecuteAsync(sql, new
        {
            Id = Guid.NewGuid(),
            IPAddress = ip,
            Path = path,
            Method = method,
            Timestamp = DateTime.UtcNow
        });
    }
}