using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.Register;
public interface IRegisterExpenseUseCase
{
    Task<long> Execute(Expense expense);
}
