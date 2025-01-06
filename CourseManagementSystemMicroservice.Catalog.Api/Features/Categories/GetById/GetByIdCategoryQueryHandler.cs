using AutoMapper;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;
using CourseManagementSystemMicroservice.Shared;
using MediatR;
using System.Net;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetById;

public class GetByIdCategoryQueryHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<GetByIdCategoryQuery, ServiceResult<CategoryDto>>
{
    public async Task<ServiceResult<CategoryDto>> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
    {
        var category =await context.Categories.FindAsync(request.Id,cancellationToken);
        if(category is null)
        {
            return ServiceResult<CategoryDto>.Error("Category not found", $"This category could not be found by this ID. {request.Id} ",HttpStatusCode.NotFound);
        }
        var categoryAsDto = mapper.Map<CategoryDto>(category);

        return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
    }
}
