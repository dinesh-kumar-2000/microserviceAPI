using System.Data;

namespace Ecommerce.IdentityService.Application.Interfaces.Dapper;

public interface IDapperRepository
{
    Task<T> ExecuteScalarAsync<T>(string sql, object param = null);
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null);
    Task<int> ExecuteAsync(string sql, object param = null);
    Task<IEnumerable<TReturn>> QueryAsync<T1, T2, TReturn>(
    string sql,
    Func<T1, T2, TReturn> map,
    object param = null,
    string splitOn = "Id",
    CommandType commandType = CommandType.Text
);

    Task<IEnumerable<TReturn>> QueryAsync<T1, T2, T3, TReturn>(
    string sql,
    Func<T1, T2, T3, TReturn> map,
    object param = null,
    string splitOn = "Id",
    CommandType commandType = CommandType.Text
);

}
