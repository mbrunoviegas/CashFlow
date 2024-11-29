using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infra.DataAccess.Repositories;
internal class ExpensesRepositories(ApplicationDbContext dbContext) : IExpensesRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<long> CreateAsync(Expense expense)
    {
        try
        {
            var savedExpense = await _dbContext.Expenses.AddAsync(expense);
            await _dbContext.SaveChangesAsync();
            return savedExpense.Entity.Id;
        } catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
        return 0L;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task<Expense?> GetByIdAsync(long id)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id);
    }
}
