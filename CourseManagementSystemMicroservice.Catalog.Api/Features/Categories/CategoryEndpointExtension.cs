using Asp.Versioning.Builder;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Delete;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetAll;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetById;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Update;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void AddCategoryGroupEndpointExtension(this WebApplication app,ApiVersionSet apiVersionSet)
    {
        app.MapGroup("api/v{version:apiVersion}/categories").WithTags("Categories")
            .CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint()
            .DeleteCategoryGroupItemEndpoint()
            .UpdateCategoryGroupItemEndpoint()
            .WithApiVersionSet(apiVersionSet);
    }
}
