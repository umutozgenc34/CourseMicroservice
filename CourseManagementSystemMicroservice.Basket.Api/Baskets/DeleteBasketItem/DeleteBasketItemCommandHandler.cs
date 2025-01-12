using CourseManagementSystemMicroservice.Basket.Api.Const;
using CourseManagementSystemMicroservice.Basket.Api.Dtos;
using CourseManagementSystemMicroservice.Shared;
using CourseManagementSystemMicroservice.Shared.Services;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.DeleteBasketItem;

public class DeleteBasketItemCommandHandler(IDistributedCache distributedCache,IIdentityService ıdentityService) : IRequestHandler<DeleteBasketItemCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
    {
        Guid userID = ıdentityService.GetUserId;
        var cacheKey = string.Format(BasketConsts.BacketCacheKey, userID);

        var basketAsString = await distributedCache.GetStringAsync(cacheKey, token: cancellationToken);

        if (string.IsNullOrEmpty(basketAsString))
        {
            return ServiceResult.ErrorAsNotFound();
        }

        var currentBasket = JsonSerializer.Deserialize<BasketDto>(basketAsString);

        var basketItemToDelete = currentBasket!.Items.FirstOrDefault(x => x.Id == request.Id);

        if (basketItemToDelete is null)
        {
            return ServiceResult.ErrorAsNotFound();
        }

        currentBasket.Items.Remove(basketItemToDelete);

        basketAsString = JsonSerializer.Serialize(currentBasket);
        await distributedCache.SetStringAsync(cacheKey, basketAsString, token: cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
