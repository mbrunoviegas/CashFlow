using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Infra.DataAccess;
using CashFlow.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infra.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddDatabase(services, configuration);
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("MYSQL_CONNECTION_STRING");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepositories>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepositories>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepositories>();
        services.AddScoped<IUserReadOnlyRepository, UsersRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UsersRepository>();
        services.AddScoped<IUserUpdateOnlyRepository, UsersRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
