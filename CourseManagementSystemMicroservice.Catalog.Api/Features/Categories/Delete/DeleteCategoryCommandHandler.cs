using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Delete;

public class DeleteCategoryCommandHandler(BaseDbContext context) : IRequestHandler<DeleteCategoryCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FindAsync(request.Id, cancellationToken);
        if (category is null)
        {
            return ServiceResult.Error("Category not found", $"This category could not be found by this ID. {request.Id} ", HttpStatusCode.NotFound);
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
      
    }
}
