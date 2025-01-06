using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;
public class Expense
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }

    public void Update(Expense expense)
    {
        Title = expense.Title;
        Description = expense.Description;
        Date = expense.Date;
        Amount = expense.Amount;
        PaymentType = expense.PaymentType;
    }
}
