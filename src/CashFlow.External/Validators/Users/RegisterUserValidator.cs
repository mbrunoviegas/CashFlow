using CashFlow.Application.Validators;
using CashFlow.DTO.Requests;
using CashFlow.Exception.BaseException;
using CashFlow.Exception.Resources;
using FluentValidation;

namespace CashFlow.External.Validators.Users;

public class RegisterUserValidator : AbstractValidator<RegisterUserRequestDTO>, IPayloadValidator<RegisterUserRequestDTO>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ErrorMessagesResources.NAME_EMPTY);
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage(ErrorMessagesResources.EMAIL_EMPTY)
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage(ErrorMessagesResources.EMAIL_INVALID);

        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RegisterUserRequestDTO>());
    }

    void IPayloadValidator<RegisterUserRequestDTO>.Validate(RegisterUserRequestDTO entity)
    {
        var result = Validate(entity);

        if (!result.IsValid)
            throw new ErrorOnValidationException([.. result.Errors.Select(error => error.ErrorMessage)]);
    }
}