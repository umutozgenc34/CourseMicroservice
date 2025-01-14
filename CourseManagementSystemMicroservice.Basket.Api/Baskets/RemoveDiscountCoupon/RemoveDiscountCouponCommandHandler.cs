using CourseManagementSystemMicroservice.Shared.Services;
using CourseManagementSystemMicroservice.Shared;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;
using CourseManagementSystemMicroservice.Basket.Api.Const;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.RemoveDiscountCoupon;

public class RemoveDiscountCouponCommandHandler(
     IIdentityService identityService,
     IDistributedCache distributedCache
     ) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request,
        CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(BasketConsts.BacketCacheKey, identityService.GetUserId);
        var basketAsJson = await distributedCache.GetStringAsync(cacheKey,token:cancellationToken);

        if (string.IsNullOrEmpty(basketAsJson))
        {
            return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

        basket!.ClearDiscount();


        basketAsJson = JsonSerializer.Serialize(basket);

        await distributedCache.SetStringAsync(cacheKey,basketAsJson, token:cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}