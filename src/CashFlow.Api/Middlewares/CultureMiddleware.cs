using System.Globalization;

namespace CashFlow.Api.Middlewares;

public class CultureMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
        var requestCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("en");

        if(!string.IsNullOrEmpty(requestCulture) 
            && supportedLanguages.Exists(language => language.Name.Equals(requestCulture)))
        {
            cultureInfo = new CultureInfo(requestCulture);
        }
        
        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
        
        await _next(context);
    }
}
