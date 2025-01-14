using CourseManagementSystemMicroservice.Shared.Extensions;
using MediatR;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.RemoveDiscountCoupon;

public static class RemoveDiscountCouponEndpoint
{
    public static RouteGroupBuilder RemoveDiscountCouponGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/remove-discount-coupon",
                async (IMediator mediator) =>
                    (await mediator.Send(new RemoveDiscountCouponCommand())).ToGenericResult())
            .WithName("RemoveDiscountCoupon")
            .MapToApiVersion(1, 0);


        return group;
    }
}
