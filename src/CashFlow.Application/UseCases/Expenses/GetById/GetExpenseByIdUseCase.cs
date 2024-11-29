using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetById;
internal class GetExpenseByIdUseCase(IExpensesReadOnlyRepository repository) : IGetExpenseByIdUseCase
{
    private readonly IExpensesReadOnlyRepository _repository = repository;

    public async Task<Expense?> Execute(long id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
