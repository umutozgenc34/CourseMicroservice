using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Order.Application.Features.Orders.GetOrders;

public record GetOrdersQuery : IRequestByServiceResult<List<GetOrdersResponse>>;

