using CourseManagementSystemMicroservice.Shared;
using MediatR;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

public record CreateCategoryCommand(string Name): IRequest<ServiceResult<CreateCategoryResponse>>;

