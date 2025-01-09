using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Basket.Api.Baskets.AddBasketItem;

public record AddBasketItemCommand(Guid CourseId,string CourseName,decimal CoursePrice,string? ImageUrl) : IRequestByServiceResult;


//ImageUrl , CourseName catalogdan alınmama sebebi senkron iletişimi azaltmak