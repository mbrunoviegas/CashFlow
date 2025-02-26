using CashFlow.Domain.Security.Crypotography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.External.Security.Cryptography;

public class BCrypt : IPasswordEncrypter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);
}
