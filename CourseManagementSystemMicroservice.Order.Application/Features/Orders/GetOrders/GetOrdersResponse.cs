using CourseManagementSystemMicroservice.Order.Application.Features.Orders.Dtos;

namespace CourseManagementSystemMicroservice.Order.Application.Features.Orders.GetOrders;

public record GetOrdersResponse(DateTime Created,decimal TotalPrice,List<OrderItemDto>Items);
