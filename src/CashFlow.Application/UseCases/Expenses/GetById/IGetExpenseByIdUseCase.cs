using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public interface IGetExpenseByIdUseCase
{
    Task<Expense?> Execute(long id);
}
