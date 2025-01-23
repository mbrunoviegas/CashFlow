using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.Expenses.Report;
using CashFlow.Application.UseCases.Expenses.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application.Entensions;

public static class ServiceCollectionExtensions
{
    public static void AddUseCases(this IServiceCollection services)
    {
        services
            .AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>()
            .AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>()
            .AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>()
            .AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>()
            .AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>()
            .AddScoped<IReportExpenseUseCase, ReportExpenseUseCase>();
    }
}
