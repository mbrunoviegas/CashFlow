using CashFlow.Api.Mapper.Profiles;

namespace CashFlow.Api.Mapper.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ExpensesMapperProfile));
        return services;
    }
}
