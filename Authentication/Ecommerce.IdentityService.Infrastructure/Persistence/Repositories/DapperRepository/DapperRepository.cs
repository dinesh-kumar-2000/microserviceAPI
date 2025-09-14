using Dapper;
using Ecommerce.IdentityService.Application.Interfaces.Dapper;
using Ecommerce.IdentityService.Infrastructure.Persistence.Dapper;
using System.Data;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.Repositories.DapperRepository;

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

    public async Task<IEnumerable<TReturn>> QueryAsync<T1, T2, T3, TReturn>(string sql, Func<T1, T2, T3, TReturn> map, object param = null, string splitOn = "Id", CommandType commandType = CommandType.Text)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync(sql, map, param, commandType: commandType, splitOn: splitOn);
    }

    public async Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(
    string sql,
    Func<T1, T2, TReturn> map,
    object param = null,
    string splitOn = "Id",
    CommandType commandType = CommandType.Text)
    {
        using var connection = _connectionFactory.CreateConnection();
        return await connection.QueryAsync(sql, map, param, commandType: commandType, splitOn: splitOn);
    }

}