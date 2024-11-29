using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpensesUseCase
{
    Task<IEnumerable<Expense>> Execute();
}
