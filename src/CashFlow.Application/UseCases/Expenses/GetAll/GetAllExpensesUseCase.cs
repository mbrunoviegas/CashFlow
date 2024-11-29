using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
internal class GetAllExpensesUseCase(IExpensesRepository repository) : IGetAllExpensesUseCase
{
    private readonly IExpensesRepository _repository = repository;

    public async Task<IEnumerable<Expense>> Execute()
    {
        return await _repository.GetAllAsync();
    }
}
