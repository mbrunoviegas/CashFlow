using CashFlow.Application.Validators;
using CashFlow.Domain.Security.Crypotography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.DTO.Requests;
using CashFlow.External.Security.Tokens;
using CashFlow.External.Validators.Expenses;
using CashFlow.External.Validators.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.External.Entensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddValidators()
            .AddToken(configuration)
            .AddScoped<IPasswordEncrypter, Security.Cryptography.BCrypt>();
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IPayloadValidator<ExpenseRequestDTO>, ExpenseValidator>()
            .AddScoped<IPayloadValidator<RegisterUserRequestDTO>, RegisterUserValidator>();
        return services;
    }

    private static IServiceCollection AddToken(this IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration["Settings:Jwt:ExpiresMinutes"];
        var signingKey = configuration["Settings:Jwt:SigningKey"];

        services.AddScoped<IAccessTokenGenerator>(provider => new JwtTokenGenerator(60, signingKey!));
        return services;
    }
}
