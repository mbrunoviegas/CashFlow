using CashFlow.Application.Validators;
using CashFlow.DTO.Requests;
using CashFlow.Exception.BaseException;
using CashFlow.External.Validators.Expenses;
using CommonTestUtilities.Builders;

namespace CashFlow.External.Tests.Validators.Expenses;

public class ExpenseValidatorTests
{
    [Fact]
    public void Should_Not_Throw_Error_When_Payload_Is_Right()
    {
        IPayloadValidator<ExpenseRequestDTO> validator = new ExpenseValidator();

        validator.Validate(RegisterExpenseRequestDTOBuilder.Build());

        Assert.True(true);
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(null)]
    public void Should_Throw_Error_When_Title_Is_Empty(string title)
    {
        IPayloadValidator<ExpenseRequestDTO> validator = new ExpenseValidator();
        var payload = RegisterExpenseRequestDTOBuilder.Build();
        payload.Title = title;

        Assert.Throws<ErrorOnValidationException>(() => validator.Validate(payload));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Should_Throw_Error_When_Amount_Is_Zero(decimal amount)
    {
        IPayloadValidator<ExpenseRequestDTO> validator = new ExpenseValidator();
        var payload = RegisterExpenseRequestDTOBuilder.Build();
        payload.Amount = amount;

        Assert.Throws<ErrorOnValidationException>(() => validator.Validate(payload));
    }

    [Fact]
    public void Should_Throw_Error_When_Description_Is_Empty()
    {
        IPayloadValidator<ExpenseRequestDTO> validator = new ExpenseValidator();
        var payload = RegisterExpenseRequestDTOBuilder.Build();
        payload.Description = string.Empty;

        Assert.Throws<ErrorOnValidationException>(() => validator.Validate(payload));
    }

    [Fact]
    public void Should_Throw_Error_When_Date_Is_In_Future()
    {
        IPayloadValidator<ExpenseRequestDTO> validator = new ExpenseValidator();
        var payload = RegisterExpenseRequestDTOBuilder.Build();
        payload.Date = DateTime.UtcNow.AddDays(1);

        Assert.Throws<ErrorOnValidationException>(() => validator.Validate(payload));
    }
    
}
