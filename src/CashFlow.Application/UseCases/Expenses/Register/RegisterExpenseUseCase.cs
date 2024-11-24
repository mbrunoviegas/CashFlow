using CashFlow.Application.Validators;
using CashFlow.DTO.Requests;
using CashFlow.DTO.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase(IPayloadValidator<RegisterExpenseRequestDTO> validator): IRegisterExpenseUseCase
{
    private readonly IPayloadValidator<RegisterExpenseRequestDTO> _validator = validator;

    public RegisterExpenseResponseDTO Execute(RegisterExpenseRequestDTO registerExpense)
    {
        _validator.Validate(registerExpense);

        return new RegisterExpenseResponseDTO
        {
            Title = registerExpense.Title
        };
    }
}
