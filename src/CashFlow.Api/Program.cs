using CashFlow.Api.Filters;
using CashFlow.Api.Middlewares;
using CashFlow.Application.Entensions;
using CashFlow.External.Entensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidators().AddUseCases();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
