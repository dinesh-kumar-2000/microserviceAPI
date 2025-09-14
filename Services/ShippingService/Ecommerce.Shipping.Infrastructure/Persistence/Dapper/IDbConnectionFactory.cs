using System.Data;

namespace Ecommerce.Shipping.Infrastructure.Persistence.Dapper;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
