using CourseManagementSystemMicroservice.Basket.Api.Const;
using CourseManagementSystemMicroservice.Basket.Api.Data;
using CourseManagementSystemMicroservice.Basket.Api.Dtos;
using CourseManagementSystemMicroservice.Shared;
using CourseManagementSystemMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.AddBasketItem;

public class AddBasketItemCommandHandler(IDistributedCache distributedCache,IIdentityService identityService) : IRequestHandler<AddBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
    {
        // TODO: chaneg userId to real userId
        Guid userId = identityService.GetUserId;
        var cacheKey = string.Format(BasketConsts.BacketCacheKey, userId);

        var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);

        Data.Basket? currentBasket;

        var newBasketItem = new BasketItem(request.CourseId, request.CourseName, request.ImageUrl, request.CoursePrice, null);

        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new Data.Basket(userId, [newBasketItem]);
            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        currentBasket = JsonSerializer.Deserialize<Data.Basket>(basketAsString);

        var existingBasketItem = currentBasket!.Items.FirstOrDefault(x => x.Id == request.CourseId);

        if (existingBasketItem != null)
        {
            currentBasket.Items.Remove(existingBasketItem);
        }

        currentBasket.Items.Add(newBasketItem);
        await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(Data.Basket basket, string cacheKey, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basket);
        await distributedCache.SetStringAsync(cacheKey, basketAsString, token: cancellationToken);
    }
}
