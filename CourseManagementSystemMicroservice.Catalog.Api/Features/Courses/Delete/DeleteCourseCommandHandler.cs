
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Delete;

public class DeleteCourseCommandHandler(BaseDbContext context) : IRequestHandler<DeleteCourseCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course =await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
        if (course is null)
        {
            return ServiceResult.Error("Course not found", $"The course with id {request.Id} not found", HttpStatusCode.NotFound);
        }

        context.Courses.Remove(course);
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult.SuccessAsNoContent();
    }
}
