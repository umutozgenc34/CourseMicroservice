using CourseManagementSystemMicroservice.Order.Application.Contracts.Repositories;
using CourseManagementSystemMicroservice.Order.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystemMicroservice.Order.Persistence.Repositories;

public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Domain.Entities.Order>(context), IOrderRepository
{
    public async Task<List<Domain.Entities.Order>> GetOrderByBuyerId(Guid buyerId)
    {
        return  await context.Orders.Include(x=> x.OrderItems).Where(x => x.BuyerId == buyerId).OrderByDescending(x=> x.Created).ToListAsync();
    }
}