using CourseManagementSystemMicroservice.Shared.Extensions;
using MediatR;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetById;

public static class GetByIdCategoryQueryEndpoint
{
    public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", async (Guid id,IMediator mediator) => (await mediator.Send(new GetByIdCategoryQuery(id))).ToGenericResult())
            .WithName("GetByIdCategory")
            .MapToApiVersion(1, 0);

        return group;
    }
}
