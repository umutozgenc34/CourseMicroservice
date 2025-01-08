using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public record GetAllByUserIdQuery(Guid UserId) : IRequestByServiceResult<List<CourseDto>>;


