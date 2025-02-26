using CashFlow.Domain.Entities;
using CashFlow.DTO.Responses;

namespace CashFlow.Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    Task<RegisterUserResponseDTO> Execute(User user);
}
