using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.BaseException;
using CashFlow.Exception.Resources;

namespace CashFlow.Application.UseCases.Expenses.Update;
internal class UpdateExpenseUseCase(IExpensesUpdateOnlyRepository expenseUpdateOnlyRepository, IUnitOfWork unitOfWork) : IUpdateExpenseUseCase
{
    private readonly IExpensesUpdateOnlyRepository _expenseUpdateOnlyRepository = expenseUpdateOnlyRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Execute(long id, Expense updateExpense)
    {
        var expense = await _expenseUpdateOnlyRepository.GetByIdAsync(id) ?? throw new NotFoundException(ErrorMessagesResources.EXPENSE_NOT_FOUND);

        expense.Update(updateExpense); 

        _expenseUpdateOnlyRepository.Update(expense);

        await _unitOfWork.Commit();
    }
}
