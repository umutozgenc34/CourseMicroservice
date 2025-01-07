using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAll;

public class GetAllCourseQueryHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<GetAllCourseQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
    {
        var courses = await context.Courses.ToListAsync(cancellationToken: cancellationToken);
        var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.First(x => x.Id == course.CategoryId);
        }

        var coursesAsDto = mapper.Map<List<CourseDto>>(courses);

        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
    }
}
