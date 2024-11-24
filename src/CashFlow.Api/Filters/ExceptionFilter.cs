using CashFlow.DTO.Responses;
using CashFlow.Exception.BaseException;
using CashFlow.Exception.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CashFlow.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is CashFlowException)
        {
            HandleApplicationException(context);
        }
        else
        {
            HandleUnknownException(context);
        }
    }

    public void HandleApplicationException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException exeception)
        {
            var errorResponse = new ErrorResponse(exeception.ErrorMessages);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(errorResponse);
        } else
        {
            var errorResponse = new ErrorResponse(context.Exception.Message);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);
        }
    }

    public void HandleUnknownException(ExceptionContext context)
    {
        var errorResponse = new ErrorResponse(ErrorMessagesResources.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}
