using AutoMapper;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;
using CourseManagementSystemMicroservice.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetAll;

public class GetAllCategoryQueryHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
{
    public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories.ToListAsync(cancellationToken:cancellationToken);
        var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);

        return ServiceResult<List<CategoryDto>>.SuccessAsOk(categoriesAsDto);
    }

}
