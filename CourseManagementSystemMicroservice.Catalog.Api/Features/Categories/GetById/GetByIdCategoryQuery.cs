using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetById;

public record GetByIdCategoryQuery(Guid Id) : IRequestByServiceResult<CategoryDto>;

