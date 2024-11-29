using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnitOfWork unitOfWork): IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<long> Execute(Expense expense)
    {
        var createdExpense = await _repository.CreateAsync(expense);

        await _unitOfWork.Commit();

        return createdExpense;
    }
}
