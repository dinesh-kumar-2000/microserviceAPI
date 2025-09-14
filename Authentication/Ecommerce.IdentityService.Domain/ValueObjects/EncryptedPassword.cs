using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.IdentityService.Domain.ValueObjects;

public class EncryptedPassword
{
    public string Hash { get; }
    private EncryptedPassword(string hash) => Hash = hash;

    public static EncryptedPassword FromPlain(string plainPassword)
    {
        string hash = BCrypt.Net.BCrypt.HashPassword(plainPassword);
        return new EncryptedPassword(hash);
    }

    public static EncryptedPassword FromHash(string hash) => new(hash);

    public static bool Verify(string plainPassword, string storedHash)
        => BCrypt.Net.BCrypt.Verify(plainPassword, storedHash);
}

