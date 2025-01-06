using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

public record CreateCategoryCommand(string Name): IRequestByServiceResult<CreateCategoryResponse>;

