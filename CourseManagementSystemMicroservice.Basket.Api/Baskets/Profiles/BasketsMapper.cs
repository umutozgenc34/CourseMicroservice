using AutoMapper;
using CourseManagementSystemMicroservice.Basket.Api.Data;
using CourseManagementSystemMicroservice.Basket.Api.Dtos;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.Profiles;

public class BasketsMapper : Profile
{
    public BasketsMapper()
    {
        CreateMap<Data.Basket, BasketDto>().ReverseMap();
        CreateMap<Data.BasketItem, BasketItemDto>().ReverseMap(); 
    }
}
