using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.BaseException;

namespace CashFlow.Application.UseCases.Expenses.Delete;

internal class DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnitOfWork unitOfWork) : IDeleteExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(long id)
    {
        var isDeleted = await _repository.DeleteAsync(id);

        if(!isDeleted)
        {
            throw new NotFoundException("Expense not found.");
        }

        await _unitOfWork.Commit();
    }
}
