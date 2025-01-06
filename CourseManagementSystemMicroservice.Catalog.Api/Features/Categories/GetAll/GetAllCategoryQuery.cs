using Amazon.Runtime.Internal;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseManagementSystemMicroservice.Shared;
using MediatR;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetAll;

public class GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;

