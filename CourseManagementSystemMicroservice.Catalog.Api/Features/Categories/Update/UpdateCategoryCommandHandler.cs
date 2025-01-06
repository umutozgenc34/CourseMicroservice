using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Update;

public class UpdateCategoryCommandHandler(BaseDbContext context) : IRequestHandler<UpdateCategoryCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FirstOrDefaultAsync(c=> c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return ServiceResult.Error("Category not found", $"This category could not be found by this ID. {request.Id} ", HttpStatusCode.NotFound);
        }
        
        category.Name = request.Name;
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
