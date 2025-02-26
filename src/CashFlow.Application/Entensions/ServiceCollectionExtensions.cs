using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.Expenses.Report;
using CashFlow.Application.UseCases.Expenses.Report.Excel;
using CashFlow.Application.UseCases.Expenses.Report.Pdf;
using CashFlow.Application.UseCases.Expenses.Update;
using CashFlow.Application.UseCases.Login;
using CashFlow.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application.Entensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services
            .AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>()
            .AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>()
            .AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>()
            .AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>()
            .AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>()
            .AddKeyedScoped<IReportExpenseUseCase, ExcelReportExpenseUseCase>(ApplicationExtensionsKeys.EXCEL_REPORT_EXPENSE_USE_CASE)
            .AddKeyedScoped<IReportExpenseUseCase, PdfReportExpenseUseCase>(ApplicationExtensionsKeys.PDF_REPORT_EXPENSE_USE_CASE)
            .AddScoped<IRegisterUserUseCase, RegisterUserUseCase>()
            .AddScoped<ILoginUseCase, LoginUseCase>();
        return services;
    }
}
