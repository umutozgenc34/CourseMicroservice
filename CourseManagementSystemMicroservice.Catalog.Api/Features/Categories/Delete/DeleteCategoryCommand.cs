namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Delete;

public record DeleteCategoryCommand(Guid Id) : IRequestByServiceResult;

