namespace Ecommerce.Catalog.Application.Interfaces.Dapper;

public interface IDapperRepository
{
    Task<T> ExecuteScalarAsync<T>(string sql, object param = null);
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null);
    Task<int> ExecuteAsync(string sql, object param = null);
}
