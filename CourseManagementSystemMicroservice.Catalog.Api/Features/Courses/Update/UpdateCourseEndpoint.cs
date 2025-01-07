using CourseManagementSystemMicroservice.Shared.Extensions;
using CourseManagementSystemMicroservice.Shared.Filters;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Update;

public static class UpdateCourseEndpoint
{
    public static RouteGroupBuilder UpdateCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPut("/" , async (IMediator mediator, UpdateCourseCommand command) => (await mediator.Send(command)).ToGenericResult())
            .WithName("UpdateCourse")
            .AddEndpointFilter<ValidationFilter<UpdateCourseCommand>>();


        return group;
    }
}
