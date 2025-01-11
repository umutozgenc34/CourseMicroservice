using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.DeleteBasketItem;

public record DeleteBasketItemCommand(Guid Id) : IRequestByServiceResult;
