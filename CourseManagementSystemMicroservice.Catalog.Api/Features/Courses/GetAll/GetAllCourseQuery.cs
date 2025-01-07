using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAll;

public record GetAllCourseQuery : IRequestByServiceResult<List<CourseDto>>;


