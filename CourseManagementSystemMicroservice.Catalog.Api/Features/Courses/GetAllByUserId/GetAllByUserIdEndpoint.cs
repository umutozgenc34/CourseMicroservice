using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetById;
using CourseManagementSystemMicroservice.Shared.Extensions;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public static class GetAllByUserIdEndpoint
{
    public static RouteGroupBuilder GetAllByUserIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/user/{userId:guid}", async (Guid userId, IMediator mediator) => (await mediator.Send(new GetAllByUserIdQuery(userId))).ToGenericResult())
            .WithName("GetAllByUserIdCourse");

        return group;
    }
}
