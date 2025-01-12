using Asp.Versioning.Builder;
using CourseManagementSystemMicroservice.Basket.Api.Baskets.AddBasketItem;
using CourseManagementSystemMicroservice.Basket.Api.Baskets.DeleteBasketItem;
using CourseManagementSystemMicroservice.Basket.Api.Baskets.GetBasket;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets;

public static class BasketEndpointExtension
{
    public static void AddBasketGroupEndpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
            .WithApiVersionSet(apiVersionSet)
            .AddBasketItemGroupItemEndpoint()
            .DeleteBasketItemGroupItemEndpoint()
            .GetBasketGroupItemEndpoint();
    }
}
