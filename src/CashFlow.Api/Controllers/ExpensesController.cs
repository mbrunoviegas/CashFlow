using AutoMapper;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.Validators;
using CashFlow.Domain.Entities;
using CashFlow.DTO.Requests;
using CashFlow.DTO.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<IActionResult> RegisterExpense(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromServices] IPayloadValidator<RegisterExpenseRequestDTO> validator,
        [FromBody] RegisterExpenseRequestDTO request)
    {
        validator.Validate(request);
        var payload = _mapper.Map<Expense>(request);
        
        var expenseId = await useCase.Execute(payload);
        return Created(uri: string.Empty, value: new RegisterExpenseResponseDTO { Id = expenseId });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
    {
        var expenses = await useCase.Execute();
        return Ok(_mapper.Map<ExpenseResponseDTO[]>(expenses));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpenseById(
        [FromServices] IGetExpenseByIdUseCase useCase,
        [FromRoute] long id)
    {
        var expense = await useCase.Execute(id);
        return expense is null ? NoContent() : Ok(_mapper.Map<ExpenseResponseDTO>(expense));
    }
}
