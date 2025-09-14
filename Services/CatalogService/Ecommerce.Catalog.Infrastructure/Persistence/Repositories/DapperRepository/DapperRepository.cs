using Dapper;
using Ecommerce.Catalog.Application.Interfaces.Dapper;
using Ecommerce.Catalog.Infrastructure.Persistence.Dapper;

namespace Ecommerce.Catalog.Infrastructure.Persistence.Repositories.DapperRepository;

public class DapperRepository : IDapperRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DapperRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<T>(sql, param);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync<T>(sql, param);
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param);
    }

    public async Task<int> ExecuteAsync(string sql, object param = null)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, param);
    }
}