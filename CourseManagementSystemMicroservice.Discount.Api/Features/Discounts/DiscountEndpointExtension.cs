using Asp.Versioning.Builder;
using CourseManagementSystemMicroservice.Discount.Api.Features.Discounts.CreateDiscount;
using CourseManagementSystemMicroservice.Discount.Api.Features.Discounts.GetDiscountByCode;

namespace CourseManagementSystemMicroservice.Discount.Api.Features.Discounts;

public static class DiscountEndpointExtension
{
    public static void AddDiscountGroupEndpointExtension(this WebApplication app, ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/discounts").WithTags("discounts").WithApiVersionSet(apiVersionSet)
            .CreateDiscountGroupItemEndpoint()
            .GetDiscountByCodeGroupItemEndpoint();
            
    }
}
