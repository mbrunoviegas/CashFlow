namespace CashFlow.Domain.Security.Crypotography;

public interface IPasswordEncrypter
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}
