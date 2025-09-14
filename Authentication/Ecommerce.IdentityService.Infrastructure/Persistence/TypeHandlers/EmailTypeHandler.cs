using Dapper;
using Ecommerce.IdentityService.Domain.ValueObjects;
using System.Data;

namespace Ecommerce.IdentityService.Infrastructure.Persistence.TypeHandlers;

public class EmailTypeHandler : SqlMapper.TypeHandler<Email>
{
    public override Email Parse(object value)
        => new Email((string)value);

    public override void SetValue(IDbDataParameter parameter, Email value)
        => parameter.Value = value.Value;
}
