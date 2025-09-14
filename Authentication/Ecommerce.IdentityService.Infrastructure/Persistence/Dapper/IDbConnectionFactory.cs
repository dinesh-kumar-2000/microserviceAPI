using System.Data;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Dapper;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
