using Bogus;
using CashFlow.DTO.Enums;
using CashFlow.DTO.Requests;

namespace CommonTestUtilities.Builders;

public static class RegisterExpenseRequestDTOBuilder
{
    public static ExpenseRequestDTO Build()
    {
        return new Faker<ExpenseRequestDTO>()
            .RuleFor(x => x.Title, f => f.Lorem.Word())
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.Amount, f => f.Random.Decimal(1, 1000))
            .RuleFor(x => x.Date, f => f.Date.Past())
            .RuleFor(x => x.PaymentType, f => f.PickRandom<PaymentType>())
            .Generate();
    }
}
