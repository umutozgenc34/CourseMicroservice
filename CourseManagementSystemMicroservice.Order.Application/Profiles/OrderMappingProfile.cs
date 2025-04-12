using AutoMapper;
using CourseManagementSystemMicroservice.Order.Application.Features.Orders.Dtos;
using CourseManagementSystemMicroservice.Order.Domain.Entities;

namespace CourseManagementSystemMicroservice.Order.Application.Profiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderItem, OrderItemDto>().ReverseMap();
    }
}
