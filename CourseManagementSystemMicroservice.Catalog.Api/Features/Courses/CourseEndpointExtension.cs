using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Create;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;

public static class CourseEndpointExtension
{
    public static void AddCourseGroupEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/courses").WithTags("Courses")
            .CreateCourseGroupItemEndpoint();
    }
}
