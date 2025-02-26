using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Crypotography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.DTO.Requests;
using CashFlow.DTO.Responses;
using CashFlow.Exception.BaseException;

namespace CashFlow.Application.UseCases.Login;

public class LoginUseCase(
    IUserReadOnlyRepository readOnlyRepository,
    IAccessTokenGenerator tokenGenerator,
    IPasswordEncrypter encrypter
    ) : ILoginUseCase
{
    private readonly IUserReadOnlyRepository _readOnlyRepository = readOnlyRepository;
    private readonly IAccessTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IPasswordEncrypter _encrypter = encrypter;

    public async Task<RegisterUserResponseDTO> Execute(LoginRequestDTO request)
    {
        var user = await _readOnlyRepository.GetUserByEmail(request.Email) ?? throw new InvalidLoginException();

        var passwordMatch = _encrypter.Verify(request.Password, user.Password);

        if (!passwordMatch)
        {
            throw new InvalidLoginException();
        }

        return new()
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user)
        };
    }
}
