using CashFlow.Application.Validators;
using CashFlow.DTO.Requests;
using CashFlow.External.Validators.Expenses;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.External.Entensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddSingleton<IPayloadValidator<RegisterExpenseRequestDTO>, RegisterExpenseValidator>();
        return services;
    }
}
