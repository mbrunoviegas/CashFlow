using CashFlow.DTO.Requests;
using CashFlow.DTO.Responses;

namespace CashFlow.Application.UseCases.Login;

public interface ILoginUseCase
{
    Task<RegisterUserResponseDTO> Execute(LoginRequestDTO request);
}