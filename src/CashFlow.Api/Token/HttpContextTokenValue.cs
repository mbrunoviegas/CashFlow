using CashFlow.Domain.Security.Tokens;

namespace CashFlow.Api.Token;

public class HttpContextTokenValue(IHttpContextAccessor httpContextAccessor): ITokenProvider
{
    private readonly IHttpContextAccessor _contextAccessor = httpContextAccessor;

    public string TokenOnRequest()
    {
        var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authorization["Bearer ".Length..].Trim();
    }
}
