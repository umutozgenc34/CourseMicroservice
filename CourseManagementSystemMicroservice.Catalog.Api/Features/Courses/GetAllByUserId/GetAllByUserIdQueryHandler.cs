using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Dtos;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.GetAllByUserId;

public class GetAllByUserIdQueryHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<GetAllByUserIdQuery, ServiceResult<List<CourseDto>>>
{
    public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllByUserIdQuery request, CancellationToken cancellationToken)
    {
        var courses =await context.Courses.Where(x => x.UserId == request.UserId).ToListAsync(cancellationToken:cancellationToken);

        var categories = await context.Categories.ToListAsync(cancellationToken:cancellationToken);

        foreach (var course in courses)
        {
            course.Category = categories.FirstOrDefault(x => x.Id == course.CategoryId)!;
        }

        var coursesAsDto = mapper.Map<List<CourseDto>>(courses);
        return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
    }
}
