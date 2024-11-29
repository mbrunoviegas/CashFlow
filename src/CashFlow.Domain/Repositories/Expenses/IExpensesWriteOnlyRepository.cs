using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    Task<long> CreateAsync(Expense expense);
    Task<bool> DeleteAsync(long id);
}
