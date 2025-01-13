using AutoMapper;
using CourseManagementSystemMicroservice.Basket.Api.Const;
using CourseManagementSystemMicroservice.Basket.Api.Dtos;
using CourseManagementSystemMicroservice.Shared;
using CourseManagementSystemMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.GetBasket;

public class GetBasketQueryHandler(IDistributedCache distributedCache,IIdentityService identityService,IMapper mapper) : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
{
    public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(BasketConsts.BacketCacheKey, identityService.GetUserId);
        var basketAsString =await distributedCache.GetStringAsync(cacheKey,token:cancellationToken);

        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult<BasketDto>.Error("Basket not found.", HttpStatusCode.NotFound);
        }
        
        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

        var basketAsDto = mapper.Map<BasketDto>(basket);

        return ServiceResult<BasketDto>.SuccessAsOk(basketAsDto);   
    }
}
