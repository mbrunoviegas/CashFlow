using CashFlow.DTO.Requests;
using CashFlow.DTO.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
    RegisterExpenseResponseDTO Execute(RegisterExpenseRequestDTO registerExpense);
}
