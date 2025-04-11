using CourseManagementSystemMicroservice.Order.Application.Contracts.Repositories;
using CourseManagementSystemMicroservice.Order.Persistence.Contexts;

namespace CourseManagementSystemMicroservice.Order.Persistence.Repositories;

public class OrderRepository(AppDbContext context) : GenericRepository<Guid, Domain.Entities.Order>(context), IOrderRepository
{
}