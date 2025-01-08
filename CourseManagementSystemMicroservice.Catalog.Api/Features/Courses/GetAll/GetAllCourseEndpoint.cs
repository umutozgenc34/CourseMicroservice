using CourseManagementSystemMicroservice.Shared.Extensions;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAll;

public static class GetAllCourseEndpoint
{
    public static RouteGroupBuilder GetAllCoursesGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCourseQuery())).ToGenericResult())
            .WithName("GetAllCourses")
            .MapToApiVersion(1, 0);

        return group;
    }
}
