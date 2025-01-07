
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Update;

public class UpdateCourseCommandHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<UpdateCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        
        var course = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (course is null)
        {
            return ServiceResult.Error("Course not found",$"The course with id {request.Id} not found",HttpStatusCode.NotFound);
        }

        var hasCategory =await context.Categories.AnyAsync(x => x.Id == request.CategoryId,cancellationToken);
        if (!hasCategory)
        {
            return ServiceResult.Error("Category not found",HttpStatusCode.NotFound);
        }

        var hasCourse = await context.Courses.AnyAsync(x=> x.Name == request.Name && x.Id != request.Id,cancellationToken);
        if (hasCourse)
        {
            return ServiceResult.Error("Course already exists",$"The course with name already exists {request.Name}",HttpStatusCode.BadRequest);
        }

        course = mapper.Map(request,course);
        
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();

    }
}
