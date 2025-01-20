using AutoMapper;
using CourseManagementSystemMicroservice.Basket.Api.Baskets.Services;
using CourseManagementSystemMicroservice.Basket.Api.Dtos;
using CourseManagementSystemMicroservice.Shared;
using MediatR;
using System.Net;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.GetBasket;

public class GetBasketQueryHandler(IMapper mapper,BasketService basketService) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
{
    public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var basketAsString = await basketService.GetBasketFromCache(cancellationToken);

        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString)!;
        var basketDto = mapper.Map<BasketDto>(basket);

        return ServiceResult<BasketDto>.SuccessAsOk(basketDto);
    }
}
