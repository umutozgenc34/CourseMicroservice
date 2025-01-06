using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Update;

public record UpdateCategoryCommand(Guid Id,string Name) : IRequestByServiceResult;

