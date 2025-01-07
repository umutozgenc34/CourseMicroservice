using CourseManagementSystemMicroservice.Shared.Extensions;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Delete;

public static class DeleteCourseEndpoint
{
    public static RouteGroupBuilder DeleteCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) => (await mediator.Send(new DeleteCourseCommand(id))).ToGenericResult())
            .WithName("DeleteCourse");

        return group;
    }
}
