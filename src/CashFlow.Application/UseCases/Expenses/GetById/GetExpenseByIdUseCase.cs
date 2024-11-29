using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById;
internal class GetExpenseByIdUseCase(IExpensesRepository repository) : IGetExpenseByIdUseCase
{
    private readonly IExpensesRepository _repository = repository;

    public async Task<Expense?> Execute(long id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
