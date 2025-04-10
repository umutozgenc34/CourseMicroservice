using CourseManagementSystemMicroservice.Order.Application.Contracts.UnitOfWorks;
using CourseManagementSystemMicroservice.Order.Persistence.Contexts;

namespace CourseManagementSystemMicroservice.Order.Persistence.UnitOfWorks;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        return context.Database.CommitTransactionAsync(cancellationToken);
    }
}