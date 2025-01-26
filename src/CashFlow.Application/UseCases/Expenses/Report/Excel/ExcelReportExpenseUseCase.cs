using CashFlow.Domain.Entities;
using CashFlow.Domain.Entities.Extensions;
using CashFlow.Domain.Repositories.Expenses;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Report.Excel;
internal class ExcelReportExpenseUseCase(IExpensesReadOnlyRepository repository) : IReportExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _repository = repository;
    private const string CURRENCY_SYMBOL = "R$";

    public async Task<byte[]> Execute(DateOnly month)
    {
        using var workbook = new XLWorkbook();

        var worksheet = workbook.Worksheets.Add(month.ToString("Y"));
        worksheet.Columns().AdjustToContents();
        worksheet.Style.Font.SetFontName("Roboto")
            .Font.SetFontSize(10);

        AddHeader(worksheet);

        var expenses = await _repository.FilterByMonth(month);

        if (!expenses.Any()) return [];

        AddExpenses(worksheet, expenses);

        var memoryStream = new MemoryStream();
        workbook.SaveAs(memoryStream);

        return memoryStream.ToArray();
    }

    private static void AddHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = "Title";
        worksheet.Cell("B1").Value = "Description";
        worksheet.Cell("C1").Value = "Amount";
        worksheet.Cell("D1").Value = "Date";
        worksheet.Cell("E1").Value = "Payment Type";
        worksheet.Cells("A1:E1")
            .Style.Font.SetBold()
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
            .Fill.SetBackgroundColor(XLColor.FromHtml("#fcba03"));
    }

    private static void AddExpenses(IXLWorksheet worksheet, IEnumerable<Expense> expenses)
    {
        var row = 2;
        foreach (var expense in expenses)
        {
            worksheet.Cell($"A{row}").Value = expense.Title;
            worksheet.Cell($"B{row}").Value = expense.Description;
            worksheet.Cell($"C{row}").Value = expense.Amount;
            worksheet.Cell($"C{row}").Style.NumberFormat.Format = $"-{CURRENCY_SYMBOL} #,##0.00";
            worksheet.Cell($"D{row}").Value = expense.Date;
            worksheet.Cell($"E{row}").Value = expense.PaymentType.ParsePaymentType();
            row++;
        }
    }
}
