using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Crypotography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.DTO.Responses;

namespace CashFlow.Application.UseCases.Users.Register;

public class RegisterUserUseCase(
    IPasswordEncrypter encrypter, 
    IUserReadOnlyRepository readOnlyRepository, 
    IUserWriteOnlyRepository writeOnlyRepository,
    IUnitOfWork unitOfWork,
    IAccessTokenGenerator tokenGenerator) : IRegisterUserUseCase
{
    private readonly IPasswordEncrypter _encrypter = encrypter;
    private readonly IUserReadOnlyRepository _readOnlyRepository = readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository = writeOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAccessTokenGenerator _tokenGenerator = tokenGenerator;

    public async Task<RegisterUserResponseDTO> Execute(User user)
    {
        user.Password = _encrypter.Encrypt(user.Password);
        user.UserIdentifier = Guid.NewGuid();
        
        await _writeOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new()
        {
            Name = user.Name,
            Token = _tokenGenerator.Generate(user)
        };
    }
}
