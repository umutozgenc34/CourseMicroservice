using AutoMapper;
using CourseManagementSystemMicroservice.Order.Application.Contracts.Repositories;
using CourseManagementSystemMicroservice.Order.Application.Features.Orders.Dtos;
using CourseManagementSystemMicroservice.Shared.Services;
using CourseManagementSystemMicroservice.Shared;
using MediatR;

namespace CourseManagementSystemMicroservice.Order.Application.Features.Orders.GetOrders;

public class GetOrdersQueryHandler(IIdentityService identityService, IOrderRepository orderRepository, IMapper mapper) : IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrdersResponse>>>
{
    public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetOrderByBuyerId(identityService.GetUserId);

        var response = orders.Select(o => new GetOrdersResponse(o.Created, o.TotalPrice, mapper.Map<List<OrderItemDto>>(o.OrderItems))).ToList();
        return ServiceResult<List<GetOrdersResponse>>.SuccessAsOk(response);
    }
}