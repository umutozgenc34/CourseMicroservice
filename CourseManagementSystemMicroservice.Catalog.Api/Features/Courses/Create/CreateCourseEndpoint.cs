using CourseManagementSystemMicroservice.Shared.Extensions;
using CourseManagementSystemMicroservice.Shared.Filters;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Create;

public static class CreateCourseEndpoint
{
    public static RouteGroupBuilder CreateCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPost("/", async (CreateCourseCommand command, IMediator mediator) => (await mediator.Send(command)).ToGenericResult())
            .WithName("CreateCourse")
            .MapToApiVersion(1, 0)
            .Produces<Guid>(StatusCodes.Status201Created)
            .AddEndpointFilter<ValidationFilter<CreateCourseCommand>>();

        return group;
    }
}
