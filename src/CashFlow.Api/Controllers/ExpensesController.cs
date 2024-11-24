using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult RegisterExpense(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromBody] RegisterExpenseRequestDTO request)
    {
        var response = useCase.Execute(request);
        return Created(uri: string.Empty, value: response);
    }
}
