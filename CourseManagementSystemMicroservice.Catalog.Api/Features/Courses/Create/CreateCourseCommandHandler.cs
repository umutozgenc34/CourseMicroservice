
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;

namespace CourseManagementSystemMicroservice.Catalog.Api.Features.Courses.Create;

public class CreateCourseCommandHandler(BaseDbContext context,IMapper mapper) : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
{
    public async Task<ServiceResult<Guid>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var hasCategory =await context.Categories.AnyAsync(x => x.Id == request.CategoryId,cancellationToken);

        if (!hasCategory)
        {
            return ServiceResult<Guid>.Error("Category not found",HttpStatusCode.NotFound);
        }

        var hasCourse = await context.Courses.AnyAsync(x=> x.Name == request.Name,cancellationToken);
        if (hasCourse)
        {
            return ServiceResult<Guid>.Error("Course already exists",$"The course with name already exists {request.Name}",HttpStatusCode.BadRequest);
        }
        var course = mapper.Map<Course>(request);
        course.Created = DateTime.Now;
        course.Id = NewId.NextSequentialGuid();
        course.Feature = new Feature() 
        {
            Duration = 5, // KURS Videolarının toplam süresinden gelicek
            EducatorFullName = "Umut Baba", // tokendan alınacak
            Rating = 5
        };

        await context.Courses.AddAsync(course,cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return ServiceResult<Guid>.SuccessAsCreated(course.Id,$"/api/courses/{course.Id}");
    }
}
