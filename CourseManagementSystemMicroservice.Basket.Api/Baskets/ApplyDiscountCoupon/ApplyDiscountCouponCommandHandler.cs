using CourseManagementSystemMicroservice.Basket.Api.Const;
using CourseManagementSystemMicroservice.Shared;
using CourseManagementSystemMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.ApplyDiscountCoupon;

public class ApplyDiscountCouponCommandHandler(IIdentityService identityService, IDistributedCache distributedCache) : IRequestHandler<ApplyDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ApplyDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = string.Format(BasketConsts.BacketCacheKey, identityService.GetUserId);
        var basketAsString = await distributedCache.GetStringAsync(cacheKey, cancellationToken);

        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult.ErrorAsNotFound();
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

        if (!basket.Items.Any())
        {
            return ServiceResult.ErrorAsNotFound();
        }

        basket.ApplyNewDiscount(request.Coupon, request.DiscountRate);

        basketAsString = JsonSerializer.Serialize(basket);
        await distributedCache.SetStringAsync(cacheKey, basketAsString, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
