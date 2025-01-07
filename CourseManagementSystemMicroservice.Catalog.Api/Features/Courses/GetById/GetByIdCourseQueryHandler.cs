using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetById;

public class GetByIdCourseQueryHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<GetByIdCourseQuery, ServiceResult<CourseDto>>
{
    public async Task<ServiceResult<CourseDto>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (course is null)
        {
            return ServiceResult<CourseDto>.Error("Course not found",$"The course with id {request.Id} not found",HttpStatusCode.NotFound);
        }

        var category = await context.Categories.FindAsync(course.CategoryId,cancellationToken);
        course.Category = category!;

        var courseAsDto = mapper.Map<CourseDto>(course);

        return ServiceResult<CourseDto>.SuccessAsOk(courseAsDto);
    }
}
