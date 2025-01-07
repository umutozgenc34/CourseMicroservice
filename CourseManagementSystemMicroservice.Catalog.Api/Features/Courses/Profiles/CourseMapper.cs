using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Create;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Update;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Profiles;

public class CourseMapper : Profile
{
    public CourseMapper()
    {
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();
        CreateMap<UpdateCourseCommand,Course>();
    }
}
