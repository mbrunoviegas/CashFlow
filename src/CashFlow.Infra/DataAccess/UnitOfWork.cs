using CashFlow.Domain.Repositories;

namespace CashFlow.Infra.DataAccess;
internal class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
