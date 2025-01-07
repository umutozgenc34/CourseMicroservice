using CourseManagementSystemMicroservice.Shared.Extensions;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Delete;

public static class DeleteCategoryEndpoint
{
    public static RouteGroupBuilder DeleteCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
            (await mediator.Send(new DeleteCategoryCommand(id))).ToGenericResult())
            .WithName("DeleteCategory");
        return group;
    }
}
