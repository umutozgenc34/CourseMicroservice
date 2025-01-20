using CourseManagementSystemMicroservice.Basket.Api.Const;
using CourseManagementSystemMicroservice.Shared.Services;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.Services;

public class BasketService(IIdentityService identityService, IDistributedCache distributedCache)
{
    private string GetCacheKey() => string.Format(BasketConsts.BasketCacheKey, identityService.GetUserId);

    public Task<string?> GetBasketFromCache(CancellationToken cancellationToken)
    {
        return distributedCache.GetStringAsync(GetCacheKey(), token: cancellationToken);
    }

    public async Task CreateBasketCacheAsync(Data.Basket basket, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);
        await distributedCache.SetStringAsync(GetCacheKey(), basketAsString, token: cancellationToken);
    }
}
