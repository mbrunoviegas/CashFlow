using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace CashFlow.Infra.DataAccess.Repositories;
internal class ExpensesRepositories(ApplicationDbContext dbContext) : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpensesUpdateOnlyRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<long> CreateAsync(Expense expense)
    {
        var savedExpense = await _dbContext.Expenses.AddAsync(expense);
        await _dbContext.SaveChangesAsync();
        return savedExpense.Entity.Id;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    async Task<Expense?> IExpensesReadOnlyRepository.GetByIdAsync(long id)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var expense = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

        if (expense is not null)
        {
            _dbContext.Expenses.Remove(expense);
            return true;
        }

        return false;
    }

    async Task<Expense?> IExpensesUpdateOnlyRepository.GetByIdAsync(long id)
    {
        return await _dbContext.Expenses
             .FirstOrDefaultAsync(expense => expense.Id == id);
    }

    public void Update(Expense expense)
    {
        _dbContext.Update(expense);
    }

    public async Task<IEnumerable<Expense>> FilterByMonth(DateOnly month)
    {
        var startDate = new DateTime(month.Year, month.Month, 1);

        var daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
        var endDate = new DateTime(month.Year, month.Month, daysInMonth, 23, 59, 59);

        var expenses = await _dbContext.Expenses
            .AsNoTracking()
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .Where(expense => expense.Date >= startDate && expense.Date <= endDate)
            .ToListAsync();

        return expenses;
    }
}
