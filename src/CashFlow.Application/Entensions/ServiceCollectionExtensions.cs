using CashFlow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application.Entensions;

public static class ServiceCollectionExtensions
{
    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddSingleton<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
    }
}
