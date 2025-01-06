using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Delete;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetAll;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.GetById;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Update;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void AddCategoryGroupEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/categories")
            .CreateCategoryGroupItemEndpoint()
            .GetAllCategoryGroupItemEndpoint()
            .GetByIdCategoryGroupItemEndpoint()
            .DeleteCategoryGroupItemEndpoint()
            .UpdateCategoryGroupItemEndpoint();
    }
}
