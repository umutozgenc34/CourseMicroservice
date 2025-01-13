using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.ApplyDiscountCoupon;

public record ApplyDiscountCouponCommand(string Coupon, float DiscountRate) : IRequestByServiceResult;
