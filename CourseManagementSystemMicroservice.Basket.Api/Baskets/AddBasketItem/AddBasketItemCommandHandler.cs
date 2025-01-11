using CourseManagementSystemMicroservice.Basket.Api.Const;
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

        BasketDto? currentBasket;

        var newBasketItem = new BasketItemDto(request.CourseId, request.CourseName, request.ImageUrl, request.CoursePrice, null);

        if (string.IsNullOrEmpty(basketAsString))
        {
            currentBasket = new BasketDto(userId, [newBasketItem]);
            await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

            return ServiceResult.SuccessAsNoContent();
        }

        currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

        var existingBasketItem = currentBasket!.BasketItems.FirstOrDefault(x => x.Id == request.CourseId);

        if (existingBasketItem != null)
        {
            currentBasket.BasketItems.Remove(existingBasketItem);
        }

        currentBasket.BasketItems.Add(newBasketItem);
        await CreateCacheAsync(currentBasket, cacheKey, cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }

    private async Task CreateCacheAsync(BasketDto basketDto, string cacheKey, CancellationToken cancellationToken)
    {
        var basketAsString = JsonSerializer.Serialize(basketDto);
        await distributedCache.SetStringAsync(cacheKey, basketAsString, token: cancellationToken);
    }
}
