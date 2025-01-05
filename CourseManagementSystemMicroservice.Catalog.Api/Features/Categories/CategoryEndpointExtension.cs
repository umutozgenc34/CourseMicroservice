using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;

public static class CategoryEndpointExtension
{
    public static void AddCategoryGroupEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/categories").CreateCategoryGroupItemEndpoint();
    }
}
