using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities.Extensions;
public static class ExpensesExtensions
{
    public static string ParsePaymentType(this PaymentType type)
    {
        return type switch
        {
            PaymentType.Cash => "Cash",
            PaymentType.EletronicTransfer => "Eletronic Transfer",
            PaymentType.CreditCard => "Credit Card",
            PaymentType.DebitCard => "Debit Card",
            _ => "Unknown"
        };
    }
}
