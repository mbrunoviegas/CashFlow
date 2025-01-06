using CashFlow.Application.Validators;
using CashFlow.DTO.Requests;
using CashFlow.Exception.BaseException;
using CashFlow.Exception.Resources;
using FluentValidation;

namespace CashFlow.External.Validators.Expenses;

public class ExpenseValidator: AbstractValidator<ExpenseRequestDTO>, IPayloadValidator<ExpenseRequestDTO>
{
    public ExpenseValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(ErrorMessagesResources.TITLE_REQUIRED);
        RuleFor(x => x.Description).NotEmpty().WithMessage(ErrorMessagesResources.DESCRIPTION_REQUIRED);
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage(ErrorMessagesResources.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(x => x.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ErrorMessagesResources.DATE_CANNOT_BE_IN_FUTURE);
        RuleFor(x => x.PaymentType).IsInEnum().WithMessage(ErrorMessagesResources.PAYMENT_TYPE_INVALID);
    }

    void IPayloadValidator<ExpenseRequestDTO>.Validate(ExpenseRequestDTO entity)
    {
        var result = Validate(entity);

        if(!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(error => error.ErrorMessage).ToList());
    }
}
