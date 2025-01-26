using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.GetAll;
using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Application.UseCases.Expenses.Report;
using CashFlow.Application.UseCases.Expenses.Update;
using CashFlow.Application.Validators;
using CashFlow.Domain.Entities;
using CashFlow.DTO.Requests;
using CashFlow.DTO.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<IActionResult> RegisterExpense(
        [FromServices] IRegisterExpenseUseCase useCase,
        [FromServices] IPayloadValidator<ExpenseRequestDTO> validator,
        [FromBody] ExpenseRequestDTO request)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExpense(
        [FromServices] IDeleteExpenseUseCase useCase,
        [FromRoute] long id)
    {
        await useCase.Execute(id);
        return NoContent();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(
       [FromServices] IUpdateExpenseUseCase useCase,
       [FromServices] IPayloadValidator<ExpenseRequestDTO> validator,
       [FromRoute] long id,
       [FromBody] ExpenseRequestDTO request)
    {
        validator.Validate(request);
        await useCase.Execute(id, _mapper.Map<Expense>(request));

        return NoContent();
    }

    [HttpGet("report/excel")]
    public async Task<IActionResult> GetExcel(
        [FromKeyedServices(ApplicationExtensionsKeys.EXCEL_REPORT_EXPENSE_USE_CASE)] IReportExpenseUseCase useCase,
        [FromQuery] DateOnly month
        )
    {
        byte[] file = await useCase.Execute(month);

        if(file.Length > 0)
        {
            return File(file, MediaTypeNames.Application.Octet, "expenses-report.xlsx");
        }

        return NoContent();
    }
}
