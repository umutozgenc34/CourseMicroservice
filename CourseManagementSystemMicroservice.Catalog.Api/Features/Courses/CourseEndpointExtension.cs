using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Create;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Delete;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAll;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetById;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Update;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;

public static class CourseEndpointExtension
{
    public static void AddCourseGroupEndpointExtension(this WebApplication app)
    {
        app.MapGroup("api/courses").WithTags("Courses")
            .CreateCourseGroupItemEndpoint()
            .GetAllCoursesGroupItemEndpoint()
            .GetByIdCourseGroupItemEndpoint()
            .UpdateCourseGroupItemEndpoint()
            .DeleteCourseGroupItemEndpoint()
            .GetAllByUserIdCourseGroupItemEndpoint();
    }
}
