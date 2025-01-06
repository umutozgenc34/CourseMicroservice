using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseManagementSystemMicroservice.Shared;
using MediatR;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetById;

public record GetByIdCategoryQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;

