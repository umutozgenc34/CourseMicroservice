using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public List<Course>? Courses { get; set; }
}
