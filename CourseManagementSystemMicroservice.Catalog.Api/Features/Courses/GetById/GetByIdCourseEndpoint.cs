using CourseManagementSystemMicroservice.Shared.Extensions;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetById;

public static class GetByIdCourseEndpoint
{
    public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) => (await mediator.Send(new GetByIdCourseQuery(id))).ToGenericResult())
            .WithName("GetByIdCourse");

        return group;
    }
}
