using CourseManagementSystemMicroservice.Basket.Api.Baskets.Services;
using CourseManagementSystemMicroservice.Shared;
using CourseManagementSystemMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Net;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.RemoveDiscountCoupon;

public class RemoveDiscountCouponCommandHandler(
     BasketService basketService
     ) : IRequestHandler<RemoveDiscountCouponCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(RemoveDiscountCouponCommand request,
        CancellationToken cancellationToken)
    {
        var basketAsJson = await basketService.GetBasketFromCache(cancellationToken);

        if (string.IsNullOrEmpty(basketAsJson))
        {
            return ServiceResult.Error("Basket not found", HttpStatusCode.NotFound);
        }

        var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsJson);

        basket!.ClearDiscount();
        basketAsJson = JsonSerializer.Serialize(basket);
        await basketService.CreateBasketCacheAsync(basket, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}