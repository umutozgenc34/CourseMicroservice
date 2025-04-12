using CourseManagementSystemMicroservice.Order.Application.Features.Orders.Dtos;
using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Order.Application.Features.Orders.CreateOrder;

public record CreateOrderCommand(float? DiscountRate, AddressDto Address, PaymentDto Payment, List<OrderItemDto> Items) : IRequestByServiceResult;


