namespace CashFlow.Application.UseCases.Expenses.Report;
public interface IReportExpenseUseCase
{
    Task<byte[]> Execute(DateOnly month);
}
