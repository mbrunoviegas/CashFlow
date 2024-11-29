using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
internal class GetAllExpensesUseCase(IExpensesReadOnlyRepository repository) : IGetAllExpensesUseCase
{
    private readonly IExpensesReadOnlyRepository _repository = repository;

    public async Task<IEnumerable<Expense>> Execute()
    {
        return await _repository.GetAllAsync();
    }
}
