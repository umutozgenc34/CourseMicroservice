using CourseManagementSystemMicroservice.Shared.Extensions;
using CourseManagementSystemMicroservice.Shared.Filters;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Update;

public static class UpdateCategoryEndpoint
{
    public static RouteGroupBuilder UpdateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapPut("/", async (UpdateCategoryCommand command, IMediator mediator) =>
        (await mediator.Send(command)).ToGenericResult())
        .WithName("UpdateCategory")
        .AddEndpointFilter<ValidationFilter<UpdateCategoryCommand>>();

        return group;
    }
}
