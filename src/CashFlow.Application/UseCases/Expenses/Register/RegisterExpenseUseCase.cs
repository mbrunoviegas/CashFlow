using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase(IExpensesRepository repository): IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository = repository;

    public async Task<long> Execute(Expense expense)
    {
        return await _repository.CreateAsync(expense);
    }
}
