using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Create;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Profiles;

public class CourseMapper : Profile
{
    public CourseMapper()
    {
        CreateMap<CreateCourseCommand, Course>();
    }
}
