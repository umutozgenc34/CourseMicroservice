using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetById;

public record GetByIdCourseQuery(Guid Id) : IRequestByServiceResult<CourseDto>;

